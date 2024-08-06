using Microsoft.EntityFrameworkCore;

namespace Gear.Infrastructure.Data.Context
{
    public class GearContext : DbContext
    {
        public GearContext(DbContextOptions<GearContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GearContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableDetailedErrors();
        }
    }
}
