using System.ComponentModel.DataAnnotations;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Transactions;

public class WithdrawRequestDTO
{
    [Required]
    public double Value { get; set; }
}