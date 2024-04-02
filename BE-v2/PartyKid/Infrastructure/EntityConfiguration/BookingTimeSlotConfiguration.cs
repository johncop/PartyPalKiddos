using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PartyKid;

public class BookingTimeSlotConfiguration : IEntityTypeConfiguration<BookingTimeSlot>
{
    public void Configure(EntityTypeBuilder<BookingTimeSlot> builder)
    {
        builder.HasKey(x => new { x.BookingId, x.AvailableTimeSlotId });
    }
}
