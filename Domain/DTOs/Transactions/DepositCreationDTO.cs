
using InPay__CuriousCat_BackEnd.Domain.Models.Enums;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Transactions;
public class DepositCreationDTO(double value, int accId)
{
    public EnumTransactionDirection Direction { get; set; } = EnumTransactionDirection.IN;
    public EnumTransactionType Type { get; set; } = EnumTransactionType.DEPOSIT;
    public EnumTransactionStatus Status { get; set; } = EnumTransactionStatus.DONE;
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public double Value { get; set; } = value;

    public int AccountId { get; set; } = accId;
}