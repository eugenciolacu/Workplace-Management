﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Dal.Repository.Interface
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        T Add(T t);
        Task<T> AddAsyn(T t);

        long Count();
        Task<long> CountAsync();

        void Delete(T entity);
        Task<long> DeleteAsyn(T entity);

        void Dispose();

        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);

        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate);

        T Get(long id);
        Task<T> GetAsync(long id);

        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsyn();

        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        void Save();
        Task<long> SaveAsync();

        T Update(T t, object key);
        Task<T> UpdateAsyn(T t, object key);
    }
}
