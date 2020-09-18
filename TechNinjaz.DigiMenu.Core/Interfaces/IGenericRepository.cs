using System.Collections.Generic;
using System.Threading.Tasks;
using TechNinjaz.DigiMenu.Core.Entities;

namespace TechNinjaz.DigiMenu.Core.Interfaces
{
    public interface IGenericRepository <T> where T : class, IBaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> SaveAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}