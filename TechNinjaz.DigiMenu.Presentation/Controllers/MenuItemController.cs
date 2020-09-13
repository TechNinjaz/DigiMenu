using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Service;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class MenuItemController : CustomBaseController<MenuItem> 
    {
        private readonly MenuItemService _menuItemService;
      
        public MenuItemController(MenuItemService menuItemService, IMapper mapper) : base(mapper)
        {
            _menuItemService = menuItemService;
        }

        public override async Task<MenuItem> Create(MenuItem entity)
        {
            return await _menuItemService.Save(entity);
        }

        public override async Task<MenuItem> Update(MenuItem entity)
        {
            return await _menuItemService.Update(entity);
        }

        public override async Task<MenuItem> GetById(int id)
        {
            return await _menuItemService.GetById(id);
        }

        public override async Task<IEnumerable<MenuItem>> GetAll()
        {
            return await _menuItemService.GetAll();
        }
    }
}