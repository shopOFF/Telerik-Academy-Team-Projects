using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ES6.Data.Contracts;
using ES6.Data.Migrations;
using ES6.Models.Features;
using ES6.Models.Platforms;
using ES6.ParseModels.Support;

namespace ES6.Data
{
    public class Es6DbContext : DbContext, IEs6DbContext
    {
        public Es6DbContext()
            : base("EcmaScriptDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Es6DbContext, Configuration>());
        }

        public virtual IDbSet<Feature> Features { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<SubCategory> SubCategories { get; set; }

        public virtual IDbSet<Platform> Platforms { get; set; }

        public virtual IDbSet<PlatformType> PlatformTypes { get; set; }

        public virtual IDbSet<Support> Support { get; set; }

        public new IDbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
