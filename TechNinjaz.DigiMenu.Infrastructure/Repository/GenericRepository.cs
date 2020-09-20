using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechNinjaz.DigiMenu.Core.Interfaces;
using TechNinjaz.DigiMenu.Infrastructure.Context;

namespace TechNinjaz.DigiMenu.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity 
    {
        private readonly RestaurantDbContext _context;

        public GenericRepository(RestaurantDbContext context)
        {
            _context = context;
        }
        
        public async Task<T> SaveAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity ?? throw new ArgumentNullException(nameof(entity)));
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity ?? throw new ArgumentNullException(nameof(entity))).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await EagerLoadingQueryable().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await EagerLoadingQueryable().SingleOrDefaultAsync(s=>s.Id.Equals(id));
        }
        
        
        private IQueryable<T> EagerLoadingQueryable()
        {
            // to be changed, only use it for now
            return typeof(T).GetProperties()
                .Select(info =>  new { info, p_name = info.PropertyType.FullName})
                .Where(prop => prop.p_name != null)
                .Where(prop => prop.p_name.Contains(typeof(T).Assembly.FullName!))
                .Select(prop => prop.info)
                .Where(info => info.PropertyType.BaseType == null)
                .Aggregate(_context.Set<T>().AsQueryable(),
                    (current, pInfo) => current.Include(pInfo.Name));
        } 

    }
}