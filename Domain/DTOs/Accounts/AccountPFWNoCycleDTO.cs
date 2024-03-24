
namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;

public class AccountWNoCycleDTO
{
    public int Id { get; set; }

    //PF Account data
    public string? CPF { get; set; }
    public string? Name { get; set; }
    public DateTime? BirthDay { get; set; }

    // All Account Data

    public int AccNumber { get; set; }
    public string Agency { get; set; } = null!;
    public string AccNickName { get; set; } = null!;
    public double Balance { get; set; }
    public double AccLimit { get; set; }
    public double ConfiguredAccLimit { get; set; }
    public double AvailableLimit { get; set; }
    public double TransactionLimit { get; set; }
    public string? AccRecoveryCode { get; set; }
}