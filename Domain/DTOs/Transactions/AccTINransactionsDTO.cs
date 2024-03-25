
using InPay__CuriousCat_BackEnd.Domain.Models.Enums;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Transactions;
public class AccTINransactionsDTO
{
    public string Status { get; set; } = null!;
    public DateTime Date { get; set; }
    public double Value { get; set; }
    public int AccFromID { get; set; }

}