﻿using EcmaScriptCompatability.Contracts;
using EcmaScriptCompatability.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace EcmaScriptCompatability.Repositories.EntityFramework
{
    public class EfRepository<T> : IRepository<T>
        where T : class
    {

        private readonly IEcmaScriptDbContext context;

        public EfRepository(IEcmaScriptDbContext context)
        {
            if (context == null)
            {
                throw new NullReferenceException();
            }

            this.context = context;
            this.DbSet = this.context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.GetAll(null);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression)
        {
            return this.GetAll<object>(filterExpression, null);
        }

        public IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression)
        {
            return this.GetAll<T1, T>(filterExpression, sortExpression, null);
        }

        public IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, Expression<Func<T, T2>> selectExpression)
        {
            IQueryable<T> result = this.DbSet;

            if (filterExpression != null)
            {
                result = result.Where(filterExpression);
            }

            if (sortExpression != null)
            {
                result = result.OrderBy(sortExpression);
            }

            if (selectExpression != null)
            {

                return result.Select(selectExpression).ToList();
            }
            else
            {
                return result.OfType<T2>().ToList();
            }
        }

        public void Add(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            DbEntityEntry entry;
            try
            {
                entry = this.context.Entry(entity);

            }
            catch (Exception e)
            {

                throw;
            }
            if (entry.State == EntityState.Detached)
            {
                try
                {
                    this.DbSet.Attach(entity);

                }
                catch (Exception e )
                {

                }
            }

            return entry;
        }
    }
}
