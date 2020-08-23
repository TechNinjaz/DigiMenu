using System;
using Microsoft.AspNetCore.Identity;
using TechNinjaz.DigiMenu.Domain.@interface;

namespace TechNinjaz.DigiMenu.Domain
{
    public class ApplicationUser : IdentityUser, IEntity
    {
        public Organization Organization { get; set; }
    }
    
}