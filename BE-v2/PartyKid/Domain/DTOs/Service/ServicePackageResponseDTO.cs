namespace PartyKid;

public class ServicePackageResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public ServicePackageStatusCollection Status { get; set; }
    public IList<ServiceResponseDTO> Services { get; set; }
    public IList<ServicePackageImageDTO> Images { get; set; }
}
