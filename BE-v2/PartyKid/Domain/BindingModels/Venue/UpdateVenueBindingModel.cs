﻿namespace PartyKid;

public class UpdateVenueBindingModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public int? Capacity { get; set; }
    public decimal? Price { get; set; }
    public string? OpenHour { get; set; }
    public string? CloseHour { get; set; }
    public IList<string>? ImageUrls { get; set; }
    public int? DisctrictId { get; set; }

    public IList<int>? Foods { get; set; }
    public IList<int>? Services { get; set; }
    public IList<int>? ServicePackages { get; set; }
    public IList<int>? Combos { get; set; }
}
