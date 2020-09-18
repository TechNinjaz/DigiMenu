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
    public class MenuItemController : CustomBaseController<MenuItem> 
    {
        private readonly IGenericService<MenuItem> _menuItemService;

        public MenuItemController(IGenericService<MenuItem> menuItemService)
        {
            _menuItemService = menuItemService;
        }

        public override async Task<MenuItem> Create(MenuItem entity)
        {
            return await _menuItemService.SaveAsync(entity);
        }

        public override async Task<MenuItem> Update(MenuItem entity)
        {
            return await _menuItemService.UpdateAsync(entity);
        }

        public override async Task<MenuItem> GetById(int id)
        {
            return await _menuItemService.GetByIdAsync(id);
        }

        public override async Task<IReadOnlyList<MenuItem>> GetAll()
        {
            return await _menuItemService.GetAllAsync();
        }
    }
}