using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PartyKid;

public class VenueServiceConfiguration : IEntityTypeConfiguration<VenueService>
{
    public void Configure(EntityTypeBuilder<VenueService> builder)
    {
        builder.HasKey(vs => new { vs.VenueId, vs.ServiceId });
    }
}
