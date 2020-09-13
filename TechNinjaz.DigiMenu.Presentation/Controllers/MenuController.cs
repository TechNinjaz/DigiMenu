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
    public class MenuCategoryController: CustomBaseController<MenuCategory>
    {
        private readonly MenuCategoryService _menuService;
        public MenuCategoryController(MenuCategoryService service, IMapper mapper) : base(mapper)
        {
            _menuService = service;
        }

        public override async Task<MenuCategory> Create(MenuCategory entity)
        {
            return await _menuService.Save(entity);
        }

        public override async Task<MenuCategory> Update(MenuCategory entity)
        {
            return await _menuService.Update(entity);
        }

        public override async Task<MenuCategory> GetById(int id)
        {
            return await _menuService.GetById(id);
        }

        public override async Task<IEnumerable<MenuCategory>> GetAll()
        {
            return await _menuService.GetAll();
        }
    }
}