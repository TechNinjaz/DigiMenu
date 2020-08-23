using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TechNinjaz.DigiMenu.Domain.@interface;

namespace TechNinjaz.DigiMenu.Repository
{
    public class Repository<T> : IRepository<T> where T:DbContext 
    {
        public T1 Add<T1>(T1 entity) where T1 : class, IEntity
        {
            throw new System.NotImplementedException();
        }

        public T1 Update<T1>(T1 entity) where T1 : class, IEntity
        {
            throw new System.NotImplementedException();
        }

        public T1 GetById<T1>(T1 entity) where T1 : class, IEntity
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T1> GetAll<T1>(string org) where T1 : class, IEntity
        {
            throw new System.NotImplementedException();
        }
    }
}