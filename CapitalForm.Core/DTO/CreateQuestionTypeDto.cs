using CapitalForm.Core.Domain.Entities;

namespace CapitalForm.Core.DTO
{
    public class CreateQuestionTypeDto
    {
        public string Name { get; set; } 

        public QuestionType ToQuestionType()
        {
            return new QuestionType() { Id = Guid.NewGuid(), Name = Name };
        }
    }
}
