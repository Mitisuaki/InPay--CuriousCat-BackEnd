using System.ComponentModel.DataAnnotations;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

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