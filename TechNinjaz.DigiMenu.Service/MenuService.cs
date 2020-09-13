using System.Collections.Generic;
using System.Threading.Tasks;
using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Repository;
using TechNinjaz.DigiMenu.Service.Interface;

namespace TechNinjaz.DigiMenu.Service
{
    public class MenuCategoryService : IGenericService<MenuCategory>
    {
        private readonly MenuCategoryRepository _categoryRepository;

        public MenuCategoryService(MenuCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<MenuCategory>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<MenuCategory> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<MenuCategory> Save(MenuCategory entity)
        {
            return await _categoryRepository.Save(entity);
        }

        public async Task<MenuCategory> Update(MenuCategory entity)
        {
            return await _categoryRepository.Update(entity);
        }
    }
}