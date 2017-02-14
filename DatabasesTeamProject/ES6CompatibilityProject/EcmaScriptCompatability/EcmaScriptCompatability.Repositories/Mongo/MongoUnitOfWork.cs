using System;
using EcmaScriptCompatability.Repositories.Contracts;

namespace EcmaScriptCompatability.Repositories.Mongo
{
    public class MongoUnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
