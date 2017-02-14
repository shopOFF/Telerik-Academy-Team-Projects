using EcmaScriptCompatability.Contracts;
using EcmaScriptCompatability.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace EcmaScriptCompatability.Data
{
    public class EcmaScriptDbContext : DbContext, IEcmaScriptDbContext
    {
        public EcmaScriptDbContext()
            : base("EcmaScriptTableConnection")
        {
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<EcmaScriptDbContext, Configuration>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EcmaScriptDbContext>());
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

        public new void SaveChanges()
        {
            try
            {
                base.SaveChanges();

            }
            catch (System.Exception e)
            {

                throw;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Developer
            modelBuilder.Entity<Developer>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Developer>()
                .Property(n => n.FirstName)
                .HasMaxLength(50);

            modelBuilder.Entity<Developer>()
                .Property(n => n.LastName)
                .HasMaxLength(50);

            modelBuilder.Entity<Developer>()
                .HasRequired(x => x.PlatformEmployer)
                .WithMany(x => x.Developers)
                .WillCascadeOnDelete(false);

            //Feature
            modelBuilder.Entity<Feature>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Feature>()
                .Property(x => x.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Feature>()
                .HasRequired(x => x.Developer)
                .WithMany(d => d.Features);

            modelBuilder.Entity<Feature>()
                .HasRequired(x => x.FeatureSubCategory)
                .WithMany(d => d.Features);

            //FeatureSubCategory
            modelBuilder.Entity<FeatureSubCategory>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<FeatureSubCategory>()
                .Property(x => x.Name)
                .HasMaxLength(60);

            modelBuilder.Entity<FeatureSubCategory>()
                .HasRequired(x => x.FeatureCategory)
                .WithMany(x => x.FeatureSubCategories);

            //FeatureCategory
            modelBuilder.Entity<FeatureCategory>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<FeatureCategory>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Name", 1) { IsUnique = true }));

            modelBuilder.Entity<FeatureCategory>()
             .HasRequired(x => x.Platform)
             .WithMany(x => x.FeatureCategories);

            //Platform
            modelBuilder.Entity<Platform>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Platform>()
               .Property(x => x.Name)
               .HasMaxLength(50)
               .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Name", 1) { IsUnique = true }));


            modelBuilder.Entity<Platform>()
               .HasRequired(x => x.PlatformType)
               .WithMany(x => x.Platforms);

            //PlatformType
            modelBuilder.Entity<PlatformType>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<PlatformType>()
               .Property(x => x.Name)
               .HasMaxLength(50)
               .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Name", 1) { IsUnique = true }));
        }
    }
}
