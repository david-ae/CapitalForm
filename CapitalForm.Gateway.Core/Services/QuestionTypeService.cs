using CapitalForm.Gateway.Core.DTO;
using CapitalForm.Gateway.Core.Http;
using CapitalForm.Gateway.Core.ServiceContracts;

namespace CapitalForm.Gateway.Core.Services
{
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly FormHttpClient _webHttpClient;

        public QuestionTypeService(FormHttpClient webHttpClient)
        {
            _webHttpClient = webHttpClient;
        }

        public async Task<QuestionTypeResponse> GetQuestion(Guid Id)
        {
            return await _webHttpClient.MakeRequestAsync<string, QuestionTypeResponse>($"api/QuestionType/Questions/{Id}", HttpMethod.Get);
        }
    }
}
