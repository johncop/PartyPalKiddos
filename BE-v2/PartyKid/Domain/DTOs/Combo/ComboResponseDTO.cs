namespace PartyKid;

public class ComboResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public IList<FoodResponseDTO> Foods { get; set; }
}
