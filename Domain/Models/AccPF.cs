using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.Models;

public class AccPF : Account
{
    public string CPF { get; set; } = null!;
    public string Name { get; set; } = null!;
    public DateTime BirthDay { get; set; }
    public Adress CurrrentAdress { get; set; } = null!;
    public AccPF()
    {


    }
}