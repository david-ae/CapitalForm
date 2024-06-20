namespace CapitalForm.Core.DTO
{
    public class EditApplicationRequestDto
    {
        public Guid Id { get; set; }
        public string ProgramTitle { get; set; } = string.Empty;
        public string ProgramDescription { get; set; } = string.Empty;
        public List<InputFormatDto> Questions { get; set; } = new List<InputFormatDto>();
    }
}
