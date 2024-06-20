using CapitalForm.Core.DTO;

namespace CapitalForm.Core.Domain.Entities
{
    public class ProgramApplication : BaseEntity
    {
        public string ProgramTitle { get; set; } = string.Empty;
        public string ProgramDescription { get; set; } = string.Empty;
        public List<InputFormatDto> Questions { get; set; } = new List<InputFormatDto>();
    }
}
