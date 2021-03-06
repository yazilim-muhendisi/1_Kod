﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace tekno_egitim_web.core.Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> dogrulama);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> dogrulama);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
