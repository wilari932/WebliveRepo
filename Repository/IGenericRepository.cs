using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T Update(T entity);
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> expression, params string[] includes);
    }
}
