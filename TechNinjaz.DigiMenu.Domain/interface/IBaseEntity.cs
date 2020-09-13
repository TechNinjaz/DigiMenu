using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechNinjaz.DigiMenu.Domain.@interface
{
    public interface IBaseEntity: IEntity<int>
    {
        
    }

    public interface IEntity<T>
    {
        public T Id { get; set; }
        public virtual DateTime CreatedAt => DateTime.Now;
    }
}