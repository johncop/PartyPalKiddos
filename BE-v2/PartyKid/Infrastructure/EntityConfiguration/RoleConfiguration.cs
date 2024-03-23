using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PartyKid;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
    {
        builder.HasData(
            new IdentityRole<int>
            {
                Id = 1,
                Name = nameof(RoleCollection.Admin),
                NormalizedName = nameof(RoleCollection.Admin).ToUpper()
            },
                new IdentityRole<int>
                {
                    Id = 2,
                    Name = nameof(RoleCollection.User),
                    NormalizedName = nameof(RoleCollection.User).ToUpper()
                }
        );
    }
}
