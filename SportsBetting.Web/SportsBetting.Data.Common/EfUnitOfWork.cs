using SportsBetting.Data.Common.Contracts;
using System;

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
            try
            {
               this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Db context Exception!" + ex);
            }
        }
    }
}
