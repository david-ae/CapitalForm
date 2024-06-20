using CapitalForm.Core.Domain.Entities;
using System.ComponentModel;

namespace CapitalForm.Core.Domain.RepositoryContracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(Guid Id);
    }
}
