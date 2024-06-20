using CapitalForm.Core.Domain.Entities;

namespace CapitalForm.Core.DTO
{
    public class QuestionTypeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public static class QuestionTypeExtensions
    {
        public static QuestionTypeResponse ToQuestiontypeResponse(this QuestionType questionType)
        {
            return new QuestionTypeResponse()
            {
                Id = questionType.Id,
                Name = questionType.Name,
            };
        }
    }
}
