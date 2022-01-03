using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Domain.Mapping
{
    public class WorkplaceConfiguration : IEntityTypeConfiguration<Workplace>
    {
        public void Configure(EntityTypeBuilder<Workplace> builder)
        {
            builder.ToTable("Workplace");

            builder.Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasIndex(w => w.Name)
                .IsUnique();
            builder.HasCheckConstraint("CK_Workplace_Name", "Name != ''");
        }
    }
}
