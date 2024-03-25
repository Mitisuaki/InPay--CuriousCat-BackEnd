namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;

public class AccTokenVerificationResponseDTO(string userId, string accId, string accNumber)
{

    public string UserId { get; private set; } = userId;

    public string AccId { get; private set; } = accId;

    public string AccNumber { get; private set; } = accNumber;

}