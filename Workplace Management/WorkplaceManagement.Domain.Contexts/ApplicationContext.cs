using Microsoft.EntityFrameworkCore;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Infrastructure.Configurations;

namespace WorkplaceManagement.Domain.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Site> Sites => null!;
        public DbSet<Floor> Floors => null!;
        public DbSet<Workplace> Workplaces => null!;
        public DbSet<Employee> Employees => null!;
        public DbSet<Reservation> Reservations => null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SiteConfiguration());
            modelBuilder.ApplyConfiguration(new FloorConfiguration());
            modelBuilder.ApplyConfiguration(new WorkplaceConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
        }
    }
}
