using CapitalForm.Gateway.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CapitalForm.Gateway.Core.Http
{
    public class FormHttpClient
    {
        public HttpClient Client { get; }

        public FormHttpClient(HttpClient httpClient)
        {
            Client = httpClient;
        }

        public virtual async Task<TOut?> MakeRequestAsync<T, TOut>(string relativeAddress, HttpMethod method, T? postBody = null) where T : class
        {
            var request = new HttpRequestMessage
            {
                Method = method,
                //RequestUri = new Uri(relativeAddress),
                RequestUri = new Uri(Client.BaseAddress + relativeAddress),
                Content = new StringContent(JsonConvert.SerializeObject(postBody == null ? (object)string.Empty : postBody), Encoding.UTF8, "application/json")
            };

            request.Headers.Authorization = Client.DefaultRequestHeaders.Authorization;
            return await Send<TOut>(request);
        }
        
        public virtual async Task<FileResult> MakeFileRequestAsync<T, TOut>(string relativeAddress, HttpMethod method, T? postBody = null) where T : class
        {
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(Client.BaseAddress + relativeAddress),
                Content = new StringContent(string.Empty, Encoding.UTF8, "application/json")
            };

            request.Headers.Authorization = Client.DefaultRequestHeaders.Authorization;
            return await Download(request);
        }

        public virtual async Task<TOut?> MakeRequestRelativeAsync<T, TOut>(string relativeAddress, HttpMethod method, T? postBody = null) where T : class
        {
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(relativeAddress),
                Content = new StringContent(JsonConvert.SerializeObject(postBody), Encoding.UTF8, "application/json")
            };

            request.Headers.Authorization = Client.DefaultRequestHeaders.Authorization;
            return await Send<TOut>(request);
        }

        public virtual Task<TOut?> MakeRequestAsync<T, TOut>(string microservice, string controller, string methodName, HttpMethod method, object? fromQueryParameters = null, T? postBody = null) where T : class
            => MakeRequestAsync<T, TOut?>(relativeAddress: Extensions.GetUrl(microservice, controller, methodName, fromQueryParameters), method: method, postBody: postBody);

        public virtual async Task<TOut?> MakeMultiFormRequestAsync<T, TOut>(string relativeAddress, HttpMethod method, MultipartFormDataContent? postBody = null) where T : class
        {
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(Client.BaseAddress + relativeAddress),
                Content = postBody
            };

            request.Headers.Authorization = Client.DefaultRequestHeaders.Authorization;
            return await Send<TOut?>(request);
        }

        public async Task<byte[]> MakeRequestForFileStream<T>(string relativeAddress, HttpMethod method, T? postBody = null) where T : class
        {
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(Client.BaseAddress + relativeAddress),
                Content = new StringContent(JsonConvert.SerializeObject(postBody ?? (object)string.Empty), Encoding.UTF8, "application/json")
            };

            request.Headers.Authorization = Client.DefaultRequestHeaders.Authorization;
            return await SendRequest<byte[]>(request);
        }

        #region Private Methods

        private async Task<T?> Send<T>(HttpRequestMessage request)
        {
            var response = await Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            if(!response.IsSuccessStatusCode)
            {
                var ex = await GetException(request, response);
                throw ex;
            }

            await using var stream = await response.Content.ReadAsStreamAsync();
            using var streamReader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(streamReader);

            var result = new JsonSerializer()
                .Deserialize<T>(jsonReader);

            return result;
        }
        
        private async Task<byte[]> SendRequest<T>(HttpRequestMessage request)
        {
            var response = await Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            if(!response.IsSuccessStatusCode)
            {
                var ex = await GetException(request, response);
                throw ex;
            }

            var stream = await response.Content.ReadAsByteArrayAsync();

            var result = stream;

            return result;
        }

        private async Task<FileResult> Download(HttpRequestMessage request)
        {
            var response = await Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            if(!response.IsSuccessStatusCode)
            {
                var ex = await GetException(request, response);
                throw ex;
            }

            var stream = new MemoryStream();
            (await response.Content.ReadAsStreamAsync()).CopyTo(stream);

            var result = new FileContentResult(stream.ToArray(), "application/octet-stream");
            result.FileDownloadName = response.Content.Headers.ContentDisposition?.FileName;

            return result;
        }

        private static async Task<HttpRequestException> GetException(HttpRequestMessage request, HttpResponseMessage response)
        {
            request.Headers.TryGetValues("Connection", out var headers);
            var content = response.Content != null ? await response.Content.ReadAsStringAsync() : null;

            var url = request?.RequestUri?.ToString();
            var messageResult = new MessageResult();

            if(!string.IsNullOrEmpty(content) && content.StartsWith("{"))
            {
                messageResult = JsonConvert.DeserializeObject<MessageResult>(content);
            }
            else
            {
                messageResult.Message = content ?? "";
            }

            var ex = new HttpRequestException(messageResult?.Message, null, response.StatusCode);

            return ex;
        }
        #endregion
    }

    public class MessageResult
    {
        public string Message { get; set; } = string.Empty;
        public bool isSuccess { get; set; } = false;
    }
}
