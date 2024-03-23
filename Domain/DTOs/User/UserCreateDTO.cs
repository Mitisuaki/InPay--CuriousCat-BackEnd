using System.ComponentModel.DataAnnotations;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserCreateDTO
{

    [Required]
    public string UserName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$", ErrorMessage = "Your password doen not meet the requirements")]
    public string Password { get; set; } = null!;

    [Required]
    [Compare("Password")]
    public string PasswordConfirmation { get; set; } = null!;

    [Required]
    [MinLength(6)]
    public string RecoveryCode { get; set; } = null!;

    [Required]
    [MinLength(8)]
    public string AntiPishingCode { get; set; } = null!;

}