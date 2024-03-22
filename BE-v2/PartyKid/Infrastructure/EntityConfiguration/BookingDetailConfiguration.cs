using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PartyKid;

public class BookingDetailConfiguration : IEntityTypeConfiguration<BookingDetail>
{
    public void Configure(EntityTypeBuilder<BookingDetail> builder)
    {
        builder.HasKey(x => new
        {
            x.BookingId,
            x.FoodId,
            x.ComboId,
            x.ServiceId,
            x.ServicePackageId
        });
    }
}
