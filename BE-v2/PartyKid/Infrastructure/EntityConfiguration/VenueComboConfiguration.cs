using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PartyKid;

public class VenueComboConfiguration : IEntityTypeConfiguration<VenueCombo>
{
    public void Configure(EntityTypeBuilder<VenueCombo> builder)
    {
        builder.HasKey(x => new { x.VenueId, x.ComboId });
    }
}
