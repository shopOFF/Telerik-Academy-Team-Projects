using System.Data.Entity;
using EcmaScript6Compatability.Data.Contracts;
using EcmaScript6Compatability.Data.Migrations;
using EcmaScript6Compatability.Models;

namespace EcmaScript6Compatability.Data
{
    public class EcmaScript6DbContext : DbContext, IEcmaScript6DbContext
    {
        public EcmaScript6DbContext()
            : base("EcmaScriptTableDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EcmaScript6DbContext, Configuration>());
        }

        public virtual IDbSet<Feature> Features { get; set; }

        public virtual IDbSet<FeatureCategory> FeatureCategories { get; set; }

        public virtual IDbSet<FeatureSubCategory> FeatureSubCategories { get; set; }

        public virtual IDbSet<Platform> Platforms { get; set; }

        public virtual IDbSet<PlatformType> PlatformTypes { get; set; }

        
        public new IDbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
