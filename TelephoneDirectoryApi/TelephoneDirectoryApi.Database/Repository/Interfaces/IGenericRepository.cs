﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectoryApi.Database.Repository.Interfaces
{
    public interface IGenericRepositoryy<T> where T : class
    {
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        Task<T?> GetBy(Expression<Func<T, bool>> predicate, string includeProperties = "");
        Task<T?> GetRecenltyAdded();
        Task Insert(T entity);
        Task Delete(object id);
        void Delete(T entityToDelete);
        void Update(T entityToUpdate);
        Task Save();
    }
}
