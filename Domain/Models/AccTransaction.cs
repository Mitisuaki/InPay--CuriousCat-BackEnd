using InPay__CuriousCat_BackEnd.Domain.Models.Enums;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.Models;

public class AccTransaction
{
    public int Id { get; set; }
    public EnumTransactionDirection Direction { get; set; }
    public EnumTransactionType Type { get; set; }
    public EnumTransactionStatus Status { get; set; }
    public int Date { get; set; }
    public int Value { get; set; }
    public IAccount? AccFrom { get; set; }
    public IAccount? Accto { get; set; }
    public AccTransaction()
    {

    }
}