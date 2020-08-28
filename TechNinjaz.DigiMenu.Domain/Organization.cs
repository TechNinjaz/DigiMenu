using System;

namespace TechNinjaz.DigiMenu.Domain
{
    public class Organization
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Host { get; set; }
        public string Theme { get; set; }
    }
}