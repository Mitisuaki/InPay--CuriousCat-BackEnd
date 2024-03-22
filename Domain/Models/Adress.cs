using System.ComponentModel.DataAnnotations.Schema;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.Models;

public class Adress : Entity
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
    public bool IsACompanyAdress { get; set; }

    [ForeignKey("AccountId")]
    public int? AccountId { get; set; }
    public virtual Account? Account { get; set; }
}