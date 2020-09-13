using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Repository.Context;

namespace TechNinjaz.DigiMenu.Repository
{
    public sealed class MenuCategoryRepository : IRepository<MenuCategory>
    {
        private readonly DbSet<MenuCategory> _categories;
        private readonly ApplicationDbContext _context;

        public MenuCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
            _categories = context.Set<MenuCategory>();
        }

        public async Task<IEnumerable<MenuCategory>> GetAll()
        {
           return await _categories
               .Include(child=> child.MenuItems)
               .ToListAsync();
        }

        public async Task<MenuCategory> GetById(int id)
        {
            return await _categories.SingleOrDefaultAsync(menu=>menu.Id.Equals(id));;
        }

        public async Task<MenuCategory> Save(MenuCategory entity)
        {
           await _categories.AddAsync(entity ?? throw new ArgumentNullException(nameof(entity)));
           await _categories.SingleOrDefaultAsync();
           return entity;
        }

        public async Task<MenuCategory> Update(MenuCategory entity)
        {
            _categories.Update(entity ?? throw new ArgumentNullException(nameof(entity))).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}