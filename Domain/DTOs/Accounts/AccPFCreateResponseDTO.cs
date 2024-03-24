using InPay__CuriousCat_BackEnd.Domain.DTOs.Adresses;
using InPay__CuriousCat_BackEnd.Domain.Models;


namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;

public class AccPFCreateResponseDTO
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
    public virtual List<Card>? Cards { get; set; }
    public double Balance { get; set; }
    public double AccLimit { get; set; }
    public double ConfiguredAccLimit { get; set; }
    public double AvailableLimit { get; set; }
    public double TransactionLimit { get; set; }
    public virtual List<AccTransaction>? Transactions { get; set; }
    public AdressCreateDTO CurrentAdress { get; set; } = null!;
    public string? AccRecoveryCode { get; set; }

}