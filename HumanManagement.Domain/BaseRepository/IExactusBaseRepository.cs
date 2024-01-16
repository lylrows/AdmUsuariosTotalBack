﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.BaseRepository
{
  
    public interface IExactusBaseRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entityList);
        Task Update(T entity);
        Task UpdatePartial(T entity, params Expression<Func<T, object>>[] properties);
        Task UpdatePartialNotIncluding(T entity, params Expression<Func<T, object>>[] properties);
        Task Delete(T entity);
        Task DeleteRange(List<T> entityList);
        Task<T> Find(object id);
        Task<bool> Exist(Expression<Func<T, bool>> predicate);
        Task<T> FindPredicate(Expression<Func<T, bool>> predicate);
        Task<List<T>> FindAllPredicate(Expression<Func<T, bool>> predicate);
    }
}
