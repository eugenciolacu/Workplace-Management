using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Domain.Mapping
{
    public class FloorConfiguration : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            builder.ToTable("Floor");

            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(64);
            builder.HasIndex(f => f.Name)
                .IsUnique();
            builder.HasCheckConstraint("CK_Floor_Name", "Name != ''");
        }
    }
}
