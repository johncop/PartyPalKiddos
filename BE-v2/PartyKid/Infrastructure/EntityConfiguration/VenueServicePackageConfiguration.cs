using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PartyKid;

public class VenueServicePackageConfiguration : IEntityTypeConfiguration<VenueServicePackage>
{
    public void Configure(EntityTypeBuilder<VenueServicePackage> builder)
    {
        builder.HasKey(vsp => new { vsp.VenueId, vsp.ServicePackageId });
    }
}
