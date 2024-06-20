using CapitalForm.Core.Domain.Entities;
using CapitalForm.Core.Domain.RepositoryContracts;
using CapitalForm.Core.DTO;
using CapitalForm.Core.ServiceContracts;

namespace CapitalForm.Core.Services
{
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;

        public ProgramService(IProgramRepository programRepository)
        {
            this._programRepository = programRepository;
        }

        public async Task<ProgramApplicationResponse> CreateApplication(CreateApplicationRequestDto application)
        {
            ProgramApplication programApplication = application.ToProgramApplication();
            await _programRepository.Add(programApplication);
            return ProgramApplicationExtensions.ToProgramApplicationRespnse(programApplication);
        }
    }
}
