using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InPay__CuriousCat_BackEnd.Domain.Models.Enums;

namespace InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

public interface IAccount
{
    public EnumAccType AccType { get; set; }
    public int AccNumber { get; set; }
    public int Agency { get; set; }
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
    public int Agency { get; set; }
    public string AccNickName { get; set; } = null!;
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

    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
}