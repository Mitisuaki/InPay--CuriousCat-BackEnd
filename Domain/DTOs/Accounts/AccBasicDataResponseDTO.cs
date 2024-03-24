namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;

public class AccBasicDataResponseDTO
{
    public int AccNumber { get; set; }
    public int Agency { get; set; }
    public double Balance { get; set; }
    public double AccLimit { get; set; }
    public double ConfiguredAccLimit { get; set; }
    public double AvailableLimit { get; set; }
    public double TransactionLimit { get; set; }
}