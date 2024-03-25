using System.ComponentModel.DataAnnotations;


namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserLoginDTO
{
    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string PassWord { get; set; } = null!;

}