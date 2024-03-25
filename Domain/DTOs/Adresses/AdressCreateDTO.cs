using System.ComponentModel.DataAnnotations;


namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Adresses;

public class AdressCreateDTO
{
    [Required]
    public string CEP { get; set; } = null!;
    [Required]
    public string Street { get; set; } = null!;
    [Required]
    public int Number { get; set; }
    [Required]
    public string Neighborhood { get; set; } = null!;
    [Required]
    public string City { get; set; } = null!;
    [Required]
    public string State { get; set; } = null!;
    [Required]
    public string Country { get; set; } = null!;
    [Required]
    public string Complement { get; set; } = null!;
}