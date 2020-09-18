using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Core.Entities;
using TechNinjaz.DigiMenu.Core.Interfaces;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class MenuCategoryController: CustomBaseController<MenuCategory>
    {
        private readonly IGenericRepository<MenuCategory> _menuService;

        public MenuCategoryController(IGenericRepository<MenuCategory> menuService)
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