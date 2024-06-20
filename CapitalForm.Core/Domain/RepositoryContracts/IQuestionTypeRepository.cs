using CapitalForm.Core.Domain.Entities;
using CapitalForm.Core.DTO;

namespace CapitalForm.Core.Domain.RepositoryContracts
{
    public interface IQuestionTypeRepository : IGenericRepository<QuestionType>
    {
        void Adder(QuestionType questionType);
    }
}
