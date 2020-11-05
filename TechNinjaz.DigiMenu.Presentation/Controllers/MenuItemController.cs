using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Core.Entities;
using TechNinjaz.DigiMenu.Core.Interfaces;
using TechNinjaz.DigiMenu.Presentation.ModelView;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    public class MenuItemController : ApiBaseController 
    {
        private readonly IGenericService<MenuItem> _menuItemService;
        private readonly IGenericService<MenuCategory> _categoryService;
        private readonly IMapper _mapper;

        public MenuItemController(IGenericService<MenuItem> menuItemService ,
            IGenericService<MenuCategory> categoryService, IMapper mapper)
        {
            _menuItemService = menuItemService;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpPost]
        public  async Task<MenuItemModel> Create(MenuItemModel entity)
        {
            return await MapModelAsync(entity);
        }
        [HttpPost]
        public  async Task<MenuItemModel> Update(MenuItemModel entity)
        {
            return await MapModelAsync(entity);
        }
        [HttpGet("{id}")]
        public  async Task<MenuItemModel> GetById(int id)
        {
            var menuItem = await _menuItemService.GetByIdAsync(id);
            return _mapper.Map<MenuItemModel>(menuItem);
        }
        
        [HttpGet("{categoryId}")]
        public async Task<IReadOnlyList<MenuItemModel>> GetByCategoryId(int categoryId)
        {
            var cats = await _categoryService.GetByIdAsync(categoryId);
            return _mapper.Map<IReadOnlyList<MenuItemModel>>(cats.MenuItems);
        }
    
        private async Task<MenuItemModel> MapModelAsync(MenuItemModel model, bool isUpdate=false)
        { 
            var mapEntity = _mapper.Map<MenuItem>(model); 
            var entity =  isUpdate ? await _menuItemService.UpdateAsync(mapEntity) : await _menuItemService.SaveAsync(mapEntity);
            return _mapper.Map<MenuItemModel>(entity);
        }
        
        
    }
}