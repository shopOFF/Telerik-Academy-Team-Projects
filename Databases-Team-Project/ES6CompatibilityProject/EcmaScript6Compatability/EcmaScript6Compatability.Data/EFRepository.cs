using EcmaScript6Compatability.Data.Contracts;
using System.Data.Entity;
using System.Linq;

namespace EcmaScript6Compatability.Data
{
    public class EFRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly IEcmaScript6DbContext dbContext;
        private readonly IDbSet<TEntity> set;

        public EFRepository(IEcmaScript6DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.set = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public IQueryable<TEntity> All()
        {
            return this.set;
        }

        public TEntity FindById(int id)
        {
            return this.set.Find(id);
        }

        public void Remove(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void SaveChanges()
        {
             this.dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        private void ChangeState(TEntity entity, EntityState state)
        {
            var dbEntity = this.dbContext.Entry(entity);
            dbEntity.State = state;
        }
    }
}
