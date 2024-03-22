using System.ComponentModel.DataAnnotations;

namespace PartyKid;

public class UpdateUserBindingModel
{
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Display(Name = "Display Name")]
    [StringLength(32, ErrorMessage = "Tên hiển thị phải nhiều hơn 1 ký tự và ít hơn 32 ký tự", MinimumLength = 1)]
    public string DisplayName { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }
}
