using System;

namespace TechNinjaz.DigiMenu.Domain.@interface
{
    public interface IEntity
    {
        public virtual Guid Id => Guid.NewGuid();
        public Organization Organization { get; set; }
    }
}