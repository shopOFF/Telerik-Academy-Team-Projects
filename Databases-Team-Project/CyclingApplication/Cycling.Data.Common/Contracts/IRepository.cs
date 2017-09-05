﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cycling.Data.Common.Contracts
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);
    }
}
