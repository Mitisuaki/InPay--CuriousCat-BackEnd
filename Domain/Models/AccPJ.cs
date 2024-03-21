using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.Models;

public class AccPJ : Account
{
    public string CNPJ { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public string CompanyEmail { get; set; } = null!;
    public string HashPasswordPJ { get; set; } = null!;
    public Adress CurrrentAdressPJ { get; set; } = null!;
    public AccPJ()
    {


    }
}