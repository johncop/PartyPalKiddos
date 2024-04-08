namespace PartyKid;

public class UpdateServicePackageBindingModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public IList<string>? Images { get; set; }
    public IList<int>? Services { get; set; }
    public ServicePackageStatusCollection? Status { get; set; }
}
