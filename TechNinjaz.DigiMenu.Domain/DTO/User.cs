using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using TechNinjaz.DigiMenu.Domain.@interface;

namespace TechNinjaz.DigiMenu.Domain.DTO
{
    [Table(nameof(User))]
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        [Required]   
        public string FistName { get; set; }
        public string LastName { get; set; }
    }
    
}