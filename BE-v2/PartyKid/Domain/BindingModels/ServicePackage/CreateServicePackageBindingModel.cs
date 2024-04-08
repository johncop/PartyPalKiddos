﻿namespace PartyKid;

public class CreateServicePackageBindingModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public IList<string> Images { get; set; }
    public IList<int> Services { get; set; }
    public ServicePackageStatusCollection Status { get; set; }
}
