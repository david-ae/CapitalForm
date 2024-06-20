using CapitalForm.Core.Domain.Entities;
using CapitalForm.Core.DTO;

namespace CapitalForm.Core.ServiceContracts
{
    public interface IQuestionTypeService
    {
        Task<QuestionTypeResponse> Add(CreateQuestionTypeDto questionType);
        Task<QuestionTypeResponse> GetQuestion(Guid Id);
        Task Delete(QuestionType questionType);
    }
}
