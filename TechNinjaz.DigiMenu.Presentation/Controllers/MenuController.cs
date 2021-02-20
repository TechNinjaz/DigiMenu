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
    [AllowAnonymous]
    public class MenuCategoryController : ApiBaseController
    {
        private readonly IGenericService<MenuCategory> _menuService;
        private readonly IMapper _mapper;

        public MenuCategoryController(IGenericService<MenuCategory> menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<MenuCategoryModel> Create(MenuCategoryModel entity)
        {
            return await MapModelAsync(entity);
        }

        [HttpPost]
        public async Task<MenuCategoryModel> Update(MenuCategoryModel entity)
        {
            return await MapModelAsync(entity, true);
        }

        [HttpGet("{id}")]
        public async Task<MenuCategoryModel> GetById(int id)
        {
            var category = await _menuService.GetByIdAsync(id);
            return _mapper.Map<MenuCategoryModel>(category);
        }
        [HttpGet]
        //[Authorize]
        public async Task<IReadOnlyList<MenuCategoryModel>> GetAll()
        {
            var categories = await _menuService.GetAllAsync();
            return _mapper.Map<IReadOnlyList<MenuCategoryModel>>(categories);
        }

        private async Task<MenuCategoryModel> MapModelAsync(MenuCategoryModel model, bool isUpdate = false)
        {
            var mapEntity = _mapper.Map<MenuCategory>(model);
            var entity = isUpdate ? await _menuService.UpdateAsync(mapEntity) : await _menuService.SaveAsync(mapEntity);
            return _mapper.Map<MenuCategoryModel>(entity);
        }
    }
}