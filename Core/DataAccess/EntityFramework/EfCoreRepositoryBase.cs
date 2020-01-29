using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).SingleOrDefaultAsync();
        }

        public async Task<TEntity> FindAsNoTrackingAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>()
            .Where(expression)
            .AsNoTracking()
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return await _context.Set<TEntity>().Where(expression)
            .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }


    }
}