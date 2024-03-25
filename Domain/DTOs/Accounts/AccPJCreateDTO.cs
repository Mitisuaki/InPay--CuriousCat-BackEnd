using System.ComponentModel.DataAnnotations;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;

public class AccPJCreateDTO : AccCreateDTO
{
    [Required]
    [MinLength(14)]
    public string CNPJ { get; set; } = null!;

    [Required]
    public string CompanyName { get; set; } = null!;

    [Required]
    public string CompanyEmail { get; set; } = null!;

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$", ErrorMessage = "Your password doen not meet the requirements")]
    public string Password { get; set; } = null!;

    [Required]
    [Compare("Password")]
    public string PasswordConfirmation { get; set; } = null!;

}