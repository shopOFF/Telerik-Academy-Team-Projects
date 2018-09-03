using SportsBetting.Data.Common.Contracts;

namespace SportsBetting.Data.Common
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        private readonly SportsBettingDbContext dbContext;

        public EfUnitOfWork(SportsBettingDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
