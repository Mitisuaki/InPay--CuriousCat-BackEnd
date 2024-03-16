namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

using System.ComponentModel.DataAnnotations;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

public class UserResponseDTO : Entity
{

    [Required(AllowEmptyStrings = false, ErrorMessage = "Informção de Nickname obrigatório!")]
    [StringLength(20, MinimumLength = 5)]
    [Display(Name = "NickName")]
    public string? NickName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Informção de Email obrigatório!")]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [RegularExpression("^((\\+\\d{2}\\s)?\\(\\d{2}\\)\\s?\\d{4}\\d?\\-\\d{4})?$", ErrorMessage = "Informe um Telefone válido!")]
    [Display(Name = "Phones")]
    public List<int>? Phones { get; set; }

    // public List<IAccount>? Accounts { get; set; }

}