using System.ComponentModel.DataAnnotations;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Transactions;

public class TransferRequestDTO
{
    [Range(1, int.MaxValue, ErrorMessage = "Inform the AccNumber that will receive the ransfer id Required")]
    public int AccToTransferNumber { get; set; }

    [Required]
    public string Agency { get; set; } = null!;
    public string? CPF { get; set; }
    public string? CNPJ { get; set; }

    [Required]
    public double Value { get; set; }
}