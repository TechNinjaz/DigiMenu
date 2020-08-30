using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Repository;
using TechNinjaz.DigiMenu.Service.Interface;

namespace TechNinjaz.DigiMenu.Service
{
    public class UserService : GenericService<User>
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }
    }
}