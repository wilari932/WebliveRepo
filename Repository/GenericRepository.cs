using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext _Context;
        public GenericRepository(DbContext context)
        {
            _Context = context;
        }
        public async Task<T> CreateAsync(T entity)
        {
           await _Context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _Context.Set<T>().Remove(entity);
           await _Context.SaveChangesAsync();
            
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            var result = await _Context.Set<T>().FirstOrDefaultAsync(expression);
            return result;
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            var result = await _Context.Set<T>().Where(expression).ToListAsync();
            return result;
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> expression, params string[] includes)
        {
            var result =  _Context.Set<T>().AsQueryable();
            
            foreach (var include in includes)
            {
               result = result.Include(include);
            }
            return await result.Where(expression).ToListAsync();
         
        }

        public T Update(T entity)
        {
             _Context.Set<T>().Update(entity);
            return entity;
        }
    }
}
