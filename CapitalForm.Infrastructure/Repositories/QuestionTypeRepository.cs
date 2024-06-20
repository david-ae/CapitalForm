using CapitalForm.Core.Domain.Entities;
using CapitalForm.Core.Domain.RepositoryContracts;
using CapitalForm.Core.DTO;
using CapitalForm.Infrastructure.Context;

namespace CapitalForm.Infrastructure.Repositories
{
    public class QuestionTypeRepository : GenericRepository<QuestionType>, IQuestionTypeRepository
    {
        public QuestionTypeRepository(ProgramContext context):base(context)
        {
            
        }

        public void Adder(QuestionType questionType)
        {
            base._context.QuestionTypes.Add(questionType);
            base._context.SaveChangesAsync();
        }
    }
}
