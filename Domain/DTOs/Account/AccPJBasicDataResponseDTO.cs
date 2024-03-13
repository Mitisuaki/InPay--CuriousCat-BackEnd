using InPay__CuriousCat_BackEnd.Domain.Models;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Account;

public class AccPJBasicDataResponseDTO
{
    public int AccNumber { get; set; }
    public int Agency { get; set; }
    public string? CNPJ { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanyEmail { get; set; }
    public Adress? CurrrentAdress { get; set; }
}