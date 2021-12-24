using Microsoft.EntityFrameworkCore;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Infrastructure.Configurations;

namespace WorkplaceManagement.Infrastructure.Context
{
    public class CoreContext : DbContext
    {
        public DbSet<Site> Sites => null!;
        public DbSet<Floor> Floors => null!;

        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SiteConfiguration());
        }
    }
}
