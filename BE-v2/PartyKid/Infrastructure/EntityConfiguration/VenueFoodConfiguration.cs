using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PartyKid;

public class VenueFoodConfiguration : IEntityTypeConfiguration<VenueFood>
{
    public void Configure(EntityTypeBuilder<VenueFood> builder)
    {
        builder.HasKey(vf => new { vf.VenueId, vf.FoodId });
    }
}
