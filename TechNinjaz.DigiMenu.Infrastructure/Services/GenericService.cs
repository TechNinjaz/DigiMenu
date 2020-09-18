using System.Collections.Generic;
using System.Threading.Tasks;
using TechNinjaz.DigiMenu.Core.Entities;
using TechNinjaz.DigiMenu.Core.Interfaces;

namespace TechNinjaz.DigiMenu.Infrastructure.Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity 
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return  await _repository.GetByIdAsync(id);
        }

        public virtual async Task<T> SaveAsync(T entity)
        {
            return await _repository.SaveAsync(entity);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}