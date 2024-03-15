using System.ComponentModel.DataAnnotations;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserUpdatePWDTO
{
    [Required]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage="Informar senha obrigatória")]
    public string? Password { get; set; }

}