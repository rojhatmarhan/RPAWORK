﻿using Microsoft.EntityFrameworkCore;
using SHARED.Data.Abstract;
using SHARED.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SHARED.Data.Concrete.NewFolder.EntityFramework
{
    public class EntityRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        public EntityRepositoryBase(DbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entity)
        {
            await _context.Set<T>().AddRangeAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => { _context.Set<T>().Remove(entity); });
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => { _context.Set<T>().Update(entity); });
        }
    }
}
