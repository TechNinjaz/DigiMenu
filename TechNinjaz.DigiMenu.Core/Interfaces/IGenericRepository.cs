using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechNinjaz.DigiMenu.Core.Interfaces
{
    public interface IGenericRepository<T> where T : IBaseEntity
    {
        Task<T> SaveAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}