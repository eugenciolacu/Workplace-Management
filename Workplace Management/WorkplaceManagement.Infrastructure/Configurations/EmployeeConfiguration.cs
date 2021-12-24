using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            //builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(64);
            builder.HasCheckConstraint("CK_Employee_FirstName", "FirstName != ''");

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasCheckConstraint("CK_Employee_LastName", "LastName != ''");

            builder.Property(e => e.Email)
                .HasMaxLength(320);
            builder.HasCheckConstraint("CK_Employee_Email", "Email != '' and Email like '%@%'");
        }
    }
}
