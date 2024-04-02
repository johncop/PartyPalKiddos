namespace PartyKid;

public class CreateFoodBindingModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public int FoodCategoryId { get; set; }
}
