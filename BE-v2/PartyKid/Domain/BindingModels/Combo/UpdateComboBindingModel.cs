﻿namespace PartyKid;

public class UpdateComboBindingModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? ImageUrl { get; set; }
    public IList<AddComboFoodBindingModel>? ComboFoods { get; set; }
    public ComboStatusCollection? Status { get; set; }
}
