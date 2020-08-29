using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechNinjaz.DigiMenu.Domain.@interface;
using TechNinjaz.DigiMenu.Repository.Context;

namespace TechNinjaz.DigiMenu.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity 
    {
        
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        protected Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities  = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _entities.SingleOrDefaultAsync(s=>s.Id.Equals(id));
        }

        public async Task<T> Save(T entity)
        {
            await _entities.AddAsync(entity ?? throw new ArgumentNullException(nameof(entity)));
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity ?? throw new ArgumentNullException(nameof(entity))).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}