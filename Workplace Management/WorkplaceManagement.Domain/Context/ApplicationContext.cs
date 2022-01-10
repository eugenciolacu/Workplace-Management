using Microsoft.EntityFrameworkCore;
using WorkplaceManagement.Domain.Mapping;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Domain.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Site> Sites { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

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
