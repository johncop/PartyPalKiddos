using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PartyKid;

public class ServicePackageDetailConfiguration : IEntityTypeConfiguration<ServicePackageDetail>
{
    public void Configure(EntityTypeBuilder<ServicePackageDetail> builder)
    {
        builder.HasKey(x => new
        {
            x.ServiceId,
            x.ServicePackageId
        });
    }
}
