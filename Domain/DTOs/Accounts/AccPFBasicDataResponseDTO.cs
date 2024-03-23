using InPay__CuriousCat_BackEnd.Domain.Models;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;

public class AccPFBasicDataResponseDTO
{
    public int AccNumber { get; set; }
    public int Agency { get; set; }
    public string? CPF { get; set; }
    public string? Name { get; set; }
    public DateTime BirthDay { get; set; }
    public Adress? CurrrentAdress { get; set; }
}