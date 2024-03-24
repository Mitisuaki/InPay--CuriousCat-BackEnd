using System.ComponentModel.DataAnnotations.Schema;
using InPay__CuriousCat_BackEnd.Domain.Models.Enums;

namespace InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

public interface IAccount
{
    public EnumAccType AccType { get; set; }
    public int AccNumber { get; set; }
    public string Agency { get; set; }
    public string AccNickName { get; set; }
    public List<Card>? Cards { get; set; }
    public double Balance { get; set; }
    public double AccLimit { get; set; }
    public double ConfiguredAccLimit { get; set; }
    public double AvailableLimit { get; set; }
    public double TransactionLimit { get; set; }
    public List<AccTransaction>? Transactions { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public List<Adress>? AdressesHistory { get; set; }
    public string? AccRecoveryCode { get; set; }

}
public class Account : Entity, IAccount
{
    public EnumAccType AccType { get; set; }

    //PF Account data
    public string? CPF { get; set; }
    public string? Name { get; set; }
    public DateTime? BirthDay { get; set; }

    // PJ Account Data
    public string? CNPJ { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanyEmail { get; set; }
    public string? HashPasswordPJ { get; set; }

    // All Account Data

    public int AccNumber { get; set; }
    public string Agency { get; set; } = "0001";
    public string AccNickName { get; set; } = null!;
    public virtual List<Card>? Cards { get; set; }
    public double Balance { get; set; } = 0;
    public double AccLimit { get; set; } = 1500;
    public double ConfiguredAccLimit { get; set; } = 1500;
    public double AvailableLimit { get; set; } = 1500;
    public double TransactionLimit { get; set; } = 500;

    public virtual List<AccTransaction>? Transactions { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public virtual List<Adress>? AdressesHistory { get; set; }
    public string? AccRecoveryCode { get; set; }

    [ForeignKey("UserId")]
    public string UserId { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}