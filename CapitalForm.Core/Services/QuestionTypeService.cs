using CapitalForm.Core.Domain.Entities;
using CapitalForm.Core.Domain.RepositoryContracts;
using CapitalForm.Core.DTO;
using CapitalForm.Core.ServiceContracts;

namespace CapitalForm.Core.Services
{
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly IQuestionTypeRepository _questionTypeRepository;
        public QuestionTypeService(IQuestionTypeRepository questionTypeRepository)
        {
            _questionTypeRepository = questionTypeRepository;
        }

        public async Task<QuestionTypeResponse> Add(CreateQuestionTypeDto questionType)
        {
            QuestionType newQuestionType = questionType.ToQuestionType();
            await _questionTypeRepository.Add(newQuestionType);
            return QuestionTypeExtensions.ToQuestiontypeResponse(newQuestionType);
        }       

        public async Task Delete(QuestionType questionType)
        {
            await _questionTypeRepository.Delete(questionType);
        }

        public async Task<QuestionTypeResponse> GetQuestion(Guid Id)
        {
            return QuestionTypeExtensions.ToQuestiontypeResponse( await _questionTypeRepository.GetById(Id));
        }
    }
}
