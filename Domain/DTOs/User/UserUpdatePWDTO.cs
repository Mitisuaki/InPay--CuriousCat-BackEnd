using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserUpdatePWDTO
{
    public int Id { get; set; }
    public string? Password { get; set; }

}