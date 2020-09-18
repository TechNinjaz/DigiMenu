using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechNinjaz.DigiMenu.Core.Entities;
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

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                .SingleOrDefaultAsync(s=>s.Id.Equals(id));
        }

        public virtual async Task<T> SaveAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity ?? throw new ArgumentNullException(nameof(entity)));
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity ?? throw new ArgumentNullException(nameof(entity))).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}