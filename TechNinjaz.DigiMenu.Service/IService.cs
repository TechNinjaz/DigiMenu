using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechNinjaz.DigiMenu.Domain.@interface;

namespace TechNinjaz.DigiMenu.Service
{
    public interface IService<T> where T : class, IBaseEntity 
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Save(T entity);
        Task<T> Update(T entity);
    }
}