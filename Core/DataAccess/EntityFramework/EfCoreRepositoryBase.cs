using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfCoreRepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;

        public EfCoreRepositoryBase(DbContext context)
        {
            _context = context;

        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Where(expression).SingleOrDefault();
        }

        public TEntity FindAsNoTracking(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public IEnumerable<TEntity> FindList(Expression<Func<TEntity, bool>> expression = null)
        {
            return _context.Set<TEntity>().Where(expression);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }


    }
}