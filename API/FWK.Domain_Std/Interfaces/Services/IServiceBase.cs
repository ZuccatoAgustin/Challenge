﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FWK.Domain.Entities;
using FWK.Domain.Interfaces.Entities;

namespace FWK.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity, TPrimaryKey>
         where TEntity : Entity<TPrimaryKey>
    {
        TEntity Add(TEntity obj);
        Task<TEntity> AddAsync(TEntity entity);


        TEntity AddOrUpdate(TEntity entity);
        Task<TEntity> AddOrUpdateAsync(TEntity entity);


        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);


        void Delete(TPrimaryKey id);
        Task DeleteAsync(TPrimaryKey id);



        TEntity GetById(TPrimaryKey id);
        Task<TEntity> GetByIdAsync(TPrimaryKey id);
        Task<TEntity> GetByIdAsync<TFilter>(TFilter filter) where TFilter : FilterPagedListBase<TEntity, TPrimaryKey>;

        PagedResult<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        Task<PagedResult<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, List<Expression<Func<TEntity, Object>>> includeExpression = null);


        PagedResult<TEntity> GetPagedList<TFilter>(TFilter filter) where TFilter : FilterPagedListBase<TEntity, TPrimaryKey>;
        Task<PagedResult<TEntity>> GetPagedListAsync<TFilter>(TFilter filter) where TFilter : FilterPagedListBase<TEntity, TPrimaryKey>, new();

        bool ExistExpression(Expression<Func<TEntity, bool>> predicate);

        void Dispose();
    }
}
