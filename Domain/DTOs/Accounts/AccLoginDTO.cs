using System.ComponentModel.DataAnnotations;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;

public class AccLoginDTO
{
    [Required]
    public int AccNumber { get; set; }

}