using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Core.Entities;
using TechNinjaz.DigiMenu.Core.Interfaces;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    public class MenuItemOptionController : ApiBaseController
    {
        private readonly IGenericService<MenuItemOption> _optionService;
        private readonly IGenericService<MenuItem> _menuItemService;

        public MenuItemOptionController(IGenericService<MenuItemOption> optionService, IGenericService<MenuItem> menuItemService)
        {
            _optionService = optionService;
            _menuItemService = menuItemService;
        }

        [HttpPost]
        public async Task<MenuItemOption> Create(MenuItemOption entity)
        {
            return await _optionService.SaveAsync(entity);
        }

        [HttpPost]
        public async Task<MenuItemOption> Update(MenuItemOption entity)
        {
            return await _optionService.UpdateAsync(entity);
        }

        [HttpGet("{id}")]
        public async Task<MenuItemOption> GetById(int id)
        {
            return await _optionService.GetByIdAsync(id);
        }

        [HttpGet("{itemId}")]
        public async Task<IReadOnlyList<MenuItemOption>> GetOptionsByItemId(int itemId)
        {
            var menuItem = await _menuItemService.GetByIdAsync(itemId);
            return menuItem.MenuItemOptions.ToList();
        }
    }
}