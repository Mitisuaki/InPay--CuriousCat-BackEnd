using System.ComponentModel.DataAnnotations;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Adresses;


namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;

public class AccCreateDTO
{
    // All Account Data

    [Required]
    public string AccNickName { get; set; } = null!;

    [Required]
    public AdressCreateDTO Adress { get; set; } = null!;

    [Required]
    public string AccRecoveryCode { get; set; } = null!;
}