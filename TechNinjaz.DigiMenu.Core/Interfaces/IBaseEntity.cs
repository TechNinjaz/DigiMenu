using System;

namespace TechNinjaz.DigiMenu.Core.Interfaces
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public virtual DateTime CreatedAt => DateTime.Now;
    }
}