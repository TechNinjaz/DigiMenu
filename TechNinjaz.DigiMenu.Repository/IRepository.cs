using System.Collections.Generic;
using TechNinjaz.DigiMenu.Domain.@interface;

namespace TechNinjaz.DigiMenu.Repository
{
    public interface IRepository <TContext> 
    {
        T Add<T>(T entity) where T : class, IEntity;
        T Update<T>(T entity)  where T : class, IEntity;
        T GetById<T>(T entity)  where T : class, IEntity;
        IEnumerable<T> GetAll<T>(string org) where T : class, IEntity;
    }
}