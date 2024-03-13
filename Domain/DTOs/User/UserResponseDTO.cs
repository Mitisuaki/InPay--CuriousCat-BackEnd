using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserResponseDTO
{
    public string? NickName { get; set; }
    public string? Email { get; set; }
    public List<int>? Phones { get; set; }
    public List<IAccount>? Accounts { get; set; }

}