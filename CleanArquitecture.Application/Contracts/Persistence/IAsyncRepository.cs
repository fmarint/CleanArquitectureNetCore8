﻿

using CleanArquitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArquitecture.Application.Contracts.Persistence
{
   public interface IAsyncRepository<T> where T : BaseDomainModel
   {
      Task<IReadOnlyList<T>> GetAllAsync();
      Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

      Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, 
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
         string includeString = null,
         bool disabledTracking = true);

      Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
         List<Expression<Func<T, object>>> includes = null,
         bool disabledTracking = true);

      Task<T> GetByIdAsync(int id);

      Task<T> AddAsync(T entity);

      Task<T> UpdateAsync(T entity);

      Task DeleteAsync(T entity);


   }
}
