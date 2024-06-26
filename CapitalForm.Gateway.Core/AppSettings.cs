namespace CapitalForm.Gateway.Core
{
    public class AppSettings
    {
        public ServiceUrl? ServiceUrl { get; set; } 
    }

    public class ServiceUrl
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string Program { get; set; } = string.Empty;
    }
}
