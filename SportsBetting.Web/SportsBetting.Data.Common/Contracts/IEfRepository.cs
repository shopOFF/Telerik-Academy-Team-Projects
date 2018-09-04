using SportsBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsBetting.Data.Common.Contracts
{
    public interface IEfRepository<T> where T : class, IDeletableEntity
    {
        IQueryable<T> GetAll { get; }
        IQueryable<T> GetAllAndDeleted { get; }
        void Add(T entity);
        void Delete(T entity);
        void DeleteForever(T entity);
        void Update(T entity);
    }
}
