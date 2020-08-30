using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Repository;
using TechNinjaz.DigiMenu.Service.Interface;

namespace TechNinjaz.DigiMenu.Service
{
    public class MenuItemService : GenericService<MenuItem>
    {
        public MenuItemService(IRepository<MenuItem> repository) : base(repository)
        {
        }
    }
}