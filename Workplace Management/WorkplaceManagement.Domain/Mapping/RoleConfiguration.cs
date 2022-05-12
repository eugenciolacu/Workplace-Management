using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorkplaceManagement.Domain.Mapping
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            // alternative data seeding
            builder.HasData(
                new IdentityRole
                {
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
            );
        }
    }
}
