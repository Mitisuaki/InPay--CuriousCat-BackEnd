using System.ComponentModel.DataAnnotations;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;

public class AccPFCreateDTO : AccCreateDTO
{
    [Required]
    public string CPF { get; set; } = null!;

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public DateTime BirthDay { get; set; }

}