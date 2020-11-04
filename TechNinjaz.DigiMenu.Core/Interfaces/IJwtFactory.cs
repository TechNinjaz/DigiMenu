using TechNinjaz.DigiMenu.Core.Entities.Identity;

namespace TechNinjaz.DigiMenu.Core.Interfaces
{
    public interface IJwtFactory
    {
        public string CreatedToken(AuthUser user);
    }
}