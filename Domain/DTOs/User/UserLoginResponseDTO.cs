using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserLoginResponseDTO
{
    public string Id { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public virtual List<Account>? Accounts { get; set; }
    public string UserToken { get; set; } = null!;

}