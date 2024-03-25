
using InPay__CuriousCat_BackEnd.Domain.Models.Enums;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Transactions;
public class AccDWTransactionsDTO
{
    public string Type { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime Date { get; set; }
    public double Value { get; set; }
}