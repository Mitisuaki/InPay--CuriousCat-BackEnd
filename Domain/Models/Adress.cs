namespace InPay__CuriousCat_BackEnd.Domain.Models;

public class Adress
{
    public string CEP { get; set; } = null!;
    public string Street { get; set; } = null!;
    public int Number { get; set; }
    public string Neighborhood { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Complement { get; set; } = String.Empty;
    public bool IsCurrentAdress { get; set; }
}