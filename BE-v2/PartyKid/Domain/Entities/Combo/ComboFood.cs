﻿namespace PartyKid;

public class ComboFood
{
    public int ComboId { get; set; }
    public Combo Combo { get; set; }

    public int FoodId { get; set; }
    public Food Food { get; set; }
}
