using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace PartyKid;

public class Food : BaseEntity
{
    public string? ImageUrl { get; set; }
    public decimal? Price { get; set; }

    public int FoodCategoryId { get; set; }
    public FoodCategory FoodCategory { get; set; }

    public ICollection<VenueFood> VenueFoods { get; set; }
    public ICollection<BookingDetail> BookingDetails { get; set; }
    public ICollection<ComboFood> ComboFoods { get; set; }
}
