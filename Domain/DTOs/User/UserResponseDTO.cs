namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

public class UserResponseDTO : Entity
{
    public string? NickName { get; set; }
    public string? Email { get; set; }
    public List<int>? Phones { get; set; }
    public List<IAccount>? Accounts { get; set; }

}