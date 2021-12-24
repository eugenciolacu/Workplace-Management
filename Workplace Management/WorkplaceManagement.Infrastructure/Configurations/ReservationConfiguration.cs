using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Infrastructure.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");

            //builder.HasKey(r => r.Id);

            //builder.HasOne(r => r.Workplace)
            //    .WithMany(w => w.Reservations)
            //    .HasForeignKey(r => r.WorkplaceId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.StratTimestamp)
                .IsRequired();
            builder.HasCheckConstraint("CK_Reservation_StratTimestamp", "StratTimestamp >= GETDATE()");
        }
    }
}
