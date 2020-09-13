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

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(s=>s.Id.Equals(id));
        }

        public virtual async Task<T> Save(T entity)
        {
            await _context.Set<T>().AddAsync(entity ?? throw new ArgumentNullException(nameof(entity)));
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            _context.Entry(entity ?? throw new ArgumentNullException(nameof(entity))).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}