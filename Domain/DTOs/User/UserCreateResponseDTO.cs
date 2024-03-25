namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserCreateResponseDTO
{
    public string Id { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string RecoveryCode { get; set; } = null!;
    public string AntiPishingCode { get; set; } = null!;
}