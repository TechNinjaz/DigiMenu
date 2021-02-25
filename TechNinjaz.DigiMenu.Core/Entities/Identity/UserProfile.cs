using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechNinjaz.DigiMenu.Core.Interfaces;

namespace TechNinjaz.DigiMenu.Core.Entities.Identity
{
    [Table(nameof(UserProfile))]
    public class UserProfile : IBaseEntity
    {
        public int Id { get; set; }
        [Required] 
        public string FistName { get; set; }
        public string LastName { get; set; }
        [DefaultValue(false)] 
        public bool IsStaffMember { get; set; }
        public string AuthUserId { get; set; }
        
        public virtual AuthUser AuthUser { get; set; }
     
    }
}