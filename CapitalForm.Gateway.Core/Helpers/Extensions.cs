using System.Web;

namespace CapitalForm.Gateway.Core.Helpers
{
    public static class Extensions
    {
        public static string GetUrl(string microservice, string controller, string method, object? fromQueryParamenters = null)
            => $"{microservice}api/{controller}/{method}{ToQueryString(fromQueryParamenters)}";

        public static string ToQueryString(object? queryParameters)
        {
            if (queryParameters == null) return "";

            List<string> queryParams = new() { };

            foreach(var prop in queryParameters.GetType().GetProperties())
            {
                string? value = prop.GetValue(queryParameters, null)?.ToString();
                if(value != null)
                {
                    queryParams.Add($"{HttpUtility.UrlEncode(prop.Name)}={HttpUtility.UrlEncode(value)}");
                }
            }

            return string.Concat("?", string.Join("&", queryParams));
        }
    }
}
