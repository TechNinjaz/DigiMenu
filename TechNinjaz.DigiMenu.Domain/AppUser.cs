using System;
using Microsoft.AspNetCore.Identity;
using TechNinjaz.DigiMenu.Domain.@interface;

namespace TechNinjaz.DigiMenu.Domain
{
    public class AppUser : IdentityUser, IEntity
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public Organization Organization { get; set; }
    }
    
}