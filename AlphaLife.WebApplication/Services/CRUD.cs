using AlphaLife.WebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AlphaLife.WebApplication.Services
{
    public class CRUD<T> : ICRUD<T> where T : class, IEntityBase, new()
    {
        private readonly ApplicationDbContext _context;
        public CRUD(ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();

        public virtual async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] icludePropreties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = icludePropreties.Aggregate(query, (current, includeProperty)=> current.Include(includeProperty));
            return await query.ToListAsync();
        }

        public virtual async Task<T> GetById(int id) => await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] icludePropreties)
        {
            IQueryable<T> query =  _context.Set<T>();
            query = icludePropreties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            var data = await query.ToListAsync();

            return data.FirstOrDefault(x=> x.Id == id);
        }

        public virtual async Task Update(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
