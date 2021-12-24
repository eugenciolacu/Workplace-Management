using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Infrastructure.Configurations
{
    public class FloorConfiguration : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            builder.ToTable("Floor");

            builder.HasKey(s => s.Id);

            builder.HasOne(x => x.Site).
                WithMany(x => x.Floors);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}
