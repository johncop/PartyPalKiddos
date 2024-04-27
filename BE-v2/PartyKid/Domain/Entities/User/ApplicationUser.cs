using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PartyKid;

public class ApplicationUser : IdentityUser<int>
{
    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    public string Address { get; set; }
    public bool IsDeleted { get; set; } = false;

    public UserStateCollection State { get; set; }
}
