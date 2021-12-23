using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Infrastructure.Configurations;

namespace WorkplaceManagement.Infrastructure.Context
{
    public class CoreContext : DbContext
    {
        public DbSet<Site> Sites => null!;

        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SiteConfiguration());
        }
    }
}
