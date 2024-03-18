namespace InPay__CuriousCat_BackEnd.Domain.Models;

using System.ComponentModel.DataAnnotations;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

public class User : Entity
{
    //[Required(AllowEmptyStrings = false, ErrorMessage="Informção de Nickname obrigatório!")]
    //[StringLength(20, MinimumLength = 5)]
    //[Display(Name = "NickName")]
    public string? NickName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage="Informção de Email obrigatório!")]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage="Informar senha obrigatória")]
    [StringLength(20, MinimumLength = 5)]
    [Display(Name = "Password")]
    public string? Password { get; set; }

    //[RegularExpression("^((\\+\\d{2}\\s)?\\(\\d{2}\\)\\s?\\d{4}\\d?\\-\\d{4})?$", ErrorMessage = "Informe um Telefone válido!")]
    [Display(Name = "Phones")]
    public List<int>? Phones { get; set; }
    //public IAccount[]? Accounts { get; set; }

    [DisplayFormat(DataFormatString	="{dd-MM-yyyy}")]
    [Display(Name = "CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [DisplayFormat(DataFormatString	="{dd-MM-yyyy}")]
    [Display(Name = "UpdatedAt")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public bool IsActive { get; set; }
    public bool IsAdmin { get; set; }
    public string? RecoveryCode { get; set; }

    public User() { }
}