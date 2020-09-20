using System.Collections.Generic;
using System.Threading.Tasks;
using TechNinjaz.DigiMenu.Core.Entities;
using TechNinjaz.DigiMenu.Core.Interfaces;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    public class MenuCategoryController: BaseApiController<MenuCategory>
    {
        private readonly IGenericService<MenuCategory> _menuService;

        public MenuCategoryController(IGenericService<MenuCategory> menuService)
        {
            _menuService = menuService;
        }

        public override async Task<MenuCategory> Create(MenuCategory entity)
        {
            return await _menuService.SaveAsync(entity);
        }

        public override async Task<MenuCategory> Update(MenuCategory entity)
        {
            return await _menuService.UpdateAsync(entity);
        }

        public override async Task<MenuCategory> GetById(int id)
        {
            return await _menuService.GetByIdAsync(id);
        }

        public override async Task<IReadOnlyList<MenuCategory>> GetAll()
        {
            return await _menuService.GetAllAsync();
        }

      
    }
}