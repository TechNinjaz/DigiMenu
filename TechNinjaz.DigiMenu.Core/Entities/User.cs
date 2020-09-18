using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using TechNinjaz.DigiMenu.Core.Interfaces;

namespace TechNinjaz.DigiMenu.Core.Entities
{
    [Table(nameof(User))]
    public class User : IdentityUser<int>, IBaseEntity
    {
        [Required]   
        public string FistName { get; set; }
        public string LastName { get; set; }
        [DefaultValue(false)]
        public bool IsStaffMember { get; set; }
    }
    
}