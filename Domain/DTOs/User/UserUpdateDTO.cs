using System.ComponentModel.DataAnnotations;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserUpdateDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage="Informção de Nickname obrigatório!")]
    public string? NickName { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage="Informção de Email obrigatório!")]
    public string? Email { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage="Informção de Email obrigatório!")]
    public List<int>? Phones { get; set; }

}