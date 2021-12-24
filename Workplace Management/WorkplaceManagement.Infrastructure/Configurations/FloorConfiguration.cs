using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Infrastructure.Configurations
{
    public class FloorConfiguration : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            builder.ToTable("Floor");

            //builder.HasKey(f => f.Id);

            //builder.HasOne(f => f.Site)
            //    .WithMany(s => s.Floors)
            //    .HasForeignKey(f => f.SiteId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(64);
            builder.HasIndex(f => f.Name)
                .IsUnique();
            builder.HasCheckConstraint("CK_Floor_Name", "Name != ''");
        }
    }
}
