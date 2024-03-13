using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.Models;

public class AccPF : IAccount
{
    public string? CPF { get; set; }
    public string? Name { get; set; }
    public DateTime BirthDay { get; set; }
    public Adress? CurrrentAdress { get; set; }

    //InterfaceMembers
    public int AccNumber { get; set; }
    public int Agency { get; set; }
    public string? AccNickName { get; set; }
    public Card[]? Cards { get; set; }
    public double Balance { get; set; }
    public double AccLimit { get; set; }
    public double ConfiguredAccLimit { get; set; }
    public double AvailableLimit { get; set; }
    public double TransactionLimit { get; set; }
    public AccTransaction? Transactions { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; }
    public Adress? AdressHistory { get; set; }
    public string? AccRecoveryCode { get; set; }

    public AccPF()
    {


    }
}