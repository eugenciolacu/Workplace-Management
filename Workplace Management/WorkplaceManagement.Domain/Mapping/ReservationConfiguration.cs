using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Domain.Mapping
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");

            builder.Property(r => r.StartTimestamp)
                .IsRequired();
            builder.HasCheckConstraint("CK_Reservation_StartTimestamp", "StartTimestamp >= SYSDATETIME()");
            builder.HasCheckConstraint("CK_Reservation_EndTimestamp", "StartTimestamp < EndTimestamp");
        }
    }
}
