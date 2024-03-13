using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.Models.TransactionsTypes;

public class Credit
{
    public int Id { get; set; }
    public double Value { get; set; }
    public DateTime PaymentDate { get; set; }
    public IAccount? AccFrom { get; set; }
    public IAccount? AccTo { get; set; }

    public Credit()
    {

    }
}