﻿namespace PartyKid;

public class Service : BaseEntity
{
    public string Image { get; set; }
    public decimal Price { get; set; }

    public int ServiceCategoryId { get; set; }
    public ServiceCategory ServiceCategory { get; set; }

    public ICollection<VenueService> VenueServices { get; set; }
}
