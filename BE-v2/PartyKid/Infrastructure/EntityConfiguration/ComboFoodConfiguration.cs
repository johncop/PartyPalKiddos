using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PartyKid;

public class ComboFoodConfiguration : IEntityTypeConfiguration<ComboFood>
{
    public void Configure(EntityTypeBuilder<ComboFood> builder)
    {
        builder.HasKey(cf => new { cf.ComboId, cf.FoodId });
    }
}
