using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SportsBetting.Data.Models;
using System;

namespace SportsBetting.Data
{

    public class SportsBettingDbContext : DbContext
    {
        public SportsBettingDbContext(DbContextOptions<SportsBettingDbContext> options) 
            : base(options) { }

        public virtual DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasIndex(b => b.EventID)
                .HasName("Index_EventID");

            modelBuilder.Entity<Event>()
                .HasIndex(b => b.IsEventPassed)
                .HasName("Index_IsEventPassed");
        }
    }

    public class SportsBettingDbFactory : IDesignTimeDbContextFactory<SportsBettingDbContext>
    {
        SportsBettingDbContext IDesignTimeDbContextFactory<SportsBettingDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SportsBettingDbContext>();
            optionsBuilder.UseSqlServer<SportsBettingDbContext>("Server = .; Database = SportsBettingDB; Trusted_Connection = True; MultipleActiveResultSets = true");

            return new SportsBettingDbContext(optionsBuilder.Options);
        }
    }
}
