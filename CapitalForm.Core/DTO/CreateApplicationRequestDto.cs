using CapitalForm.Core.Domain.Entities;

namespace CapitalForm.Core.DTO
{
    public class CreateApplicationRequestDto
    {
        public string ProgramTitle { get; set; } = string.Empty;
        public string ProgramDescription { get; set; } = string.Empty;
        public List<InputFormatDto> Questions { get; set; } = new List<InputFormatDto>();

        public ProgramApplication ToProgramApplication()
        {
            return new ProgramApplication() { 
                Id = Guid.NewGuid(), 
                ProgramDescription = ProgramDescription, 
                ProgramTitle = ProgramTitle, 
                Questions = Questions 
            };
        }
    }
}
