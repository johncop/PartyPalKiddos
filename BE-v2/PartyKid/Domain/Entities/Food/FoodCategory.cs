namespace PartyKid;

public class FoodCategory : BaseEntity
{
    public virtual ICollection<Food> Foods { get; set; }
}
