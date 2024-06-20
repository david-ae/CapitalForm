using CapitalForm.Core.Domain.Entities;
using CapitalForm.Core.Domain.RepositoryContracts;
using CapitalForm.Infrastructure.Context;

namespace CapitalForm.Infrastructure.Repositories
{
    public class ProgramRepository : GenericRepository<ProgramApplication>, IProgramRepository
    {
        public ProgramRepository(ProgramContext context):base(context) { }
    }
}
