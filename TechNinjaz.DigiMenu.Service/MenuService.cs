using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Repository;
using TechNinjaz.DigiMenu.Service.Interface;

namespace TechNinjaz.DigiMenu.Service
{
    public class MenuService : GenericService<Menu>
    {
        public MenuService(IRepository<Menu> repository) : base(repository)
        {
        }
    }
}