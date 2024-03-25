using System.ComponentModel.DataAnnotations;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserUpdateDTO
{
    [Required]
    public string UserName { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string PhoneNumber { get; set; } = null!;

}