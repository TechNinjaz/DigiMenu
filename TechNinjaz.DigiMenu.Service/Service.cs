using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechNinjaz.DigiMenu.Domain.@interface;
using TechNinjaz.DigiMenu.Repository;

namespace TechNinjaz.DigiMenu.Service
{
    public class Service<T> : IService<T> where T : class, IBaseEntity 
    {

        private readonly IRepository<T> _repository;

        protected Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T> GetById(Guid id)
        {
            return  await _repository.GetById(id);
        }

        public async Task<T> Save(T entity)
        {
            return await _repository.Save(entity);
        }

        public async Task<T> Update(T entity)
        {
            return await _repository.Update(entity);
        }
    }
}