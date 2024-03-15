using System.ComponentModel.DataAnnotations;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserUpdatePWDTO : Entity
{

    [Required(AllowEmptyStrings = false, ErrorMessage="Informar senha obrigatória")]
    [StringLength(20, MinimumLength = 5)]
    public string? Password { get; set; }

}