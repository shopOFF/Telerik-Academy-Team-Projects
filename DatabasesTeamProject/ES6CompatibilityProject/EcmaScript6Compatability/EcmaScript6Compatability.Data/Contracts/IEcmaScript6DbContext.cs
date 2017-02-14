using System.Data.Entity;
using EcmaScript6Compatability.Models;
using System.Data.Entity.Infrastructure;

namespace EcmaScript6Compatability.Data.Contracts
{
    public interface IEcmaScript6DbContext
    {
        IDbSet<FeatureCategory> FeatureCategories { get; set; }

        IDbSet<Feature> Features { get; set; }

        IDbSet<FeatureSubCategory> FeatureSubCategories { get; set; }

        IDbSet<Platform> Platforms { get; set; }

        IDbSet<PlatformType> PlatformTypes { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}