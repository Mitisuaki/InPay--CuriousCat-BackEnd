namespace InPay__CuriousCat_BackEnd.Domain.Models;

public class Adress
{
    public string? CEP { get; set; }
    public string? Street { get; set; }
    public int Number { get; set; }
    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Complement { get; set; }
    public bool IsCurrentAdress { get; set; }
}