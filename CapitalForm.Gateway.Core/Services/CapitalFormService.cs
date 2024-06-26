using CapitalForm.Gateway.Core.Http;
using CapitalForm.Gateway.Core.ServiceContracts;
using Microsoft.Extensions.Options;

namespace CapitalForm.Gateway.Core.Services
{
    public class CapitalFormService : ICapitalFormService
    {
        private readonly FormHttpClient _webHttpClient;

        public CapitalFormService(IOptions<AppSettings> options, FormHttpClient webHttpClient)
        {
            _webHttpClient = webHttpClient ?? throw new ArgumentNullException(nameof(webHttpClient));
        }

        public async Task<dynamic?> EditApplication(string applicationId)
        {
            return await _webHttpClient.MakeRequestAsync<string, dynamic>($"api/Program/application/{applicationId}", HttpMethod.Get);
        }
    }
}
