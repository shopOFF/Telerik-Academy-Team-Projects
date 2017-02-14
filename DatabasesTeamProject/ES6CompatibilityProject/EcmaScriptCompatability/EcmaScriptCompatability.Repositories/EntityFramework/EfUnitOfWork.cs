using System;
using EcmaScriptCompatability.Contracts;
using EcmaScriptCompatability.Repositories.Contracts;

namespace EcmaScriptCompatability.Repositories.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly IEcmaScriptDbContext context;

        public EfUnitOfWork(IEcmaScriptDbContext context)
        {
            if (context == null)
            {
                throw new NullReferenceException();
            }

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
