using InPay__CuriousCat_BackEnd.Domain.Models;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;

public class AccPJBasicDataResponseDTO
{
    public int AccNumber { get; set; }
    public string Agency { get; set; } = null!;
    public string? CNPJ { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanyEmail { get; set; }
    public Adress? CurrrentAdress { get; set; }
}