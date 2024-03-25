
using InPay__CuriousCat_BackEnd.Domain.Models.Enums;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Transactions;
public class WithdrawCreationDTO(double value, int accId)
{
    public EnumTransactionDirection Direction { get; set; } = EnumTransactionDirection.OUT;
    public EnumTransactionType Type { get; set; } = EnumTransactionType.WITHDRAW;
    public EnumTransactionStatus Status { get; set; } = EnumTransactionStatus.DONE;
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public double Value { get; set; } = value;

    public int AccountId { get; set; } = accId;
}