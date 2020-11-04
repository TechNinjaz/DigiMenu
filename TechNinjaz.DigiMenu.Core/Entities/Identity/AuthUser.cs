using Microsoft.AspNetCore.Identity;

namespace TechNinjaz.DigiMenu.Core.Entities.Identity
{
    public class AuthUser: IdentityUser
    {
        public string DisplayName { get; set; }
        public virtual UserProfile Profile { get; set; }
    }
}