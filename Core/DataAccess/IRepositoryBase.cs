using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
    }
}