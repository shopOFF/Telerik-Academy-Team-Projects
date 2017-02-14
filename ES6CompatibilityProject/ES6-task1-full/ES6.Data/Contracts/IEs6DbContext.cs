using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ES6.Models.Features;
using ES6.Models.Platforms;
using ES6.ParseModels.Support;

namespace ES6.Data.Contracts
{
    public interface IEs6DbContext
    {
        IDbSet<Feature> Features { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<SubCategory> SubCategories { get; set; }

        IDbSet<Platform> Platforms { get; set; }

        IDbSet<PlatformType> PlatformTypes { get; set; }

        IDbSet<Support> Support { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
