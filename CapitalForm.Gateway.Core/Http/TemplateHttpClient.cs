namespace CapitalForm.Gateway.Core.Http
{
    public class TemplateHttpClient : FormHttpClient
    {
        private HttpClient _HttpClient;

        public TemplateHttpClient(HttpClient httpClient): base(httpClient)
        {
            _HttpClient = httpClient;
        }
    }
}
