using CapitalForm.Core.DTO;

namespace CapitalForm.Core.ServiceContracts
{
    public interface IProgramService
    {
        Task<ProgramApplicationResponse> CreateApplication(CreateApplicationRequestDto application);
    }
}
