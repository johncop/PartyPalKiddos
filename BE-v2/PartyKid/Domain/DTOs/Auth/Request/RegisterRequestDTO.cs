using System.ComponentModel.DataAnnotations;

namespace PartyKid;

public class RegisterRequestDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}
