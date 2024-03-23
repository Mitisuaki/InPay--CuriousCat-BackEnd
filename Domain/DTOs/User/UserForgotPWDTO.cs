using System.ComponentModel.DataAnnotations;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserForgotPWDTO
{
    [Required]
    public string RecoveryCode { get; set; } = null!;

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$", ErrorMessage = "Your password doen not meet the requirements")]
    public string NewPassword { get; set; } = null!;

    [Required]
    [Compare("NewPassword")]
    public string NewPasswordConfirmation { get; set; } = null!;

}