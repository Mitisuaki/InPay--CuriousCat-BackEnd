using System.ComponentModel.DataAnnotations;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserLoginDTO
{
    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string PassWord { get; set; } = null!;

}