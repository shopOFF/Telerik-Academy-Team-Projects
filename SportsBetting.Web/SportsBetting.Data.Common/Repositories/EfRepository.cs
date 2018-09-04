using Microsoft.EntityFrameworkCore;
using SportsBetting.Data.Common.Contracts;
using SportsBetting.Data.Models;
using System;
using System.Linq;

namespace SportsBetting.Data.Common.Repositories
{
    public class EfRepository<T> : IEfRepository<T>
         where T : class, IDeletableEntity
    {
        private readonly SportsBettingDbContext dbContext;

        public EfRepository(SportsBettingDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public IQueryable<T> GetAll
        {
            get
            {
                return this.dbContext.Set<T>().Where(x => !x.IsDeleted);
            }
        }

        public IQueryable<T> GetAllAndDeleted
        {
            get
            {
                return this.dbContext.Set<T>();
            }
        }

        public void Add(T entity)
        {

            this.dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            var entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void DeleteForever(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbContext.Set<T>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}
