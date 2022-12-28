using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AlphaLife.WebApplication.Services
{
    public interface ICRUD<T> where T : class, IEntityBase, new()
    {
        Task Add(T entity);
        Task Update(int id, T enity);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<T> GetById(int id, params Expression<Func<T, object>>[] icludePropreties);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] icludePropreties);

    }
}
