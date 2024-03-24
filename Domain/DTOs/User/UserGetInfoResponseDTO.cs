using InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserGetInfoResponseDTO
{
    public string Id { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public virtual List<AccBasicDataResponseDTO>? Accounts { get; set; }
    public string RecoveryCode { get; set; } = null!;
    public string AntiPishingCode { get; set; } = null!;
}