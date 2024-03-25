using System.ComponentModel.DataAnnotations;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Transactions;

public class DepoistRequestDTO
{
    [Required]
    public int AccNumber { get; set; }

    [Required]
    public string Agency { get; set; } = null!;
    public string? CPF { get; set; }
    public string? CNPJ { get; set; }

    [Required]
    public double Value { get; set; }
}