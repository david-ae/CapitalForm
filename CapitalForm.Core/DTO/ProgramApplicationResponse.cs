using CapitalForm.Core.Domain.Entities;

namespace CapitalForm.Core.DTO
{
    public class ProgramApplicationResponse
    {
        public Guid Id { get; set; }
        public string ProgramTitle { get; set; } = string.Empty;
        public string ProgramDescription { get; set; } = string.Empty;
        public List<InputFormatDto> Questions { get; set; } = new List<InputFormatDto>();
    }

    public static class ProgramApplicationExtensions
    {
        public static ProgramApplicationResponse ToProgramApplicationRespnse(this ProgramApplication application)
        {
            return new ProgramApplicationResponse()
            {
                Id = application.Id,
                ProgramDescription = application.ProgramDescription,
                ProgramTitle = application.ProgramTitle,
                Questions = application.Questions,
            };
        }
    }
}
