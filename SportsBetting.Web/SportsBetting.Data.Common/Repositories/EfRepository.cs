using SportsBetting.Data.Common.Contracts;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace SportsBetting.Data.Common.Repositories
{
    public class EfRepository<T> : IEfRepository<T>
         where T : class//, IDeletableEntity
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
                return this.dbContext.Set<T>(); //.Where(x => !x.IsDeleted);
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
           // entity.IsDeleted = true;
           // entity.DeletedOn = DateTime.Now;

            var entry = this.dbContext.Entry(entity);
        }

        public void DeleteForever(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            this.dbContext.Set<T>().Attach(entity);
        }
    }
}
