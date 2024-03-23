using System.ComponentModel.DataAnnotations;

namespace PartyKid;

public class District : BaseEntity<int>
{
    [MaxLength(1000)]
    public string Description { get; set; }
    public ICollection<Venue> Venues { get; set; }
}
