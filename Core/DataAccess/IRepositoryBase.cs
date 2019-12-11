using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void Delete(T entity);

        void Update(T entity);
        T Find(Expression<Func<T, bool>> expression);

        T FindAsNoTracking(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindList(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
    }
}