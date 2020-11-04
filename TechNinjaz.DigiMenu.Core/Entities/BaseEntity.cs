using System;
using Castle.Components.DictionaryAdapter;
using TechNinjaz.DigiMenu.Core.Interfaces;

namespace TechNinjaz.DigiMenu.Core.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public virtual DateTime CreatedAt => DateTime.Now;
    }
}