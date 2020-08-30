using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechNinjaz.DigiMenu.Domain.@interface;
using TechNinjaz.DigiMenu.Repository;

namespace TechNinjaz.DigiMenu.Service.Interface
{
    public class GenericService<T> : IGenericService<T> where T : class, IBaseEntity 
    {
        private readonly IRepository<T> _repository;

        public GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return  await _repository.GetById(id);
        }

        public virtual async Task<T> Save(T entity)
        {
            return await _repository.Save(entity);
        }

        public virtual async Task<T> Update(T entity)
        {
            return await _repository.Update(entity);
        }
    }
}