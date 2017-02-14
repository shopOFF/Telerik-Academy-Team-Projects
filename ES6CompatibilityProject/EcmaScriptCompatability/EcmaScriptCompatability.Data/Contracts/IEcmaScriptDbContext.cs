using System.Data.Entity;
using EcmaScriptCompatability.Models;
using System.Data.Entity.Infrastructure;

namespace EcmaScriptCompatability.Contracts
{
    public interface IEcmaScriptDbContext
    {
        IDbSet<FeatureCategory> FeatureCategories { get; set; }

        IDbSet<Feature> Features { get; set; }

        IDbSet<FeatureSubCategory> FeatureSubCategories { get; set; }

        IDbSet<Platform> Platforms { get; set; }

        IDbSet<PlatformType> PlatformTypes { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}