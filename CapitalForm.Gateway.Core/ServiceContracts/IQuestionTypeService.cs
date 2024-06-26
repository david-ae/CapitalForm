using CapitalForm.Gateway.Core.DTO;

namespace CapitalForm.Gateway.Core.ServiceContracts
{
    public interface IQuestionTypeService
    {
        Task<QuestionTypeResponse> GetQuestion(Guid Id);
    }
}
