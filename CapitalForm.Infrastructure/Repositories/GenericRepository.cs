using CapitalForm.Core.Domain.Entities;
using CapitalForm.Core.Domain.RepositoryContracts;
using CapitalForm.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CapitalForm.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public readonly ProgramContext _context;
        public DbSet<T> entity;

        public GenericRepository(ProgramContext context)
        {
            _context = context;
            entity = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            this.entity.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            this.entity.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<List<T>> GetAll()
        {
            return this.entity.ToListAsync();
        }

        public async Task<T> GetById(Guid Id)
        {
            var entity = await _context.FindAsync<T>(Id);
            return entity;
        }

        public async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
