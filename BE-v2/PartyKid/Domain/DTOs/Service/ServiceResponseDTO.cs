﻿namespace PartyKid;

public class ServiceResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public ServiceCategoryResponseDTO ServiceCategory { get; set; }
}
