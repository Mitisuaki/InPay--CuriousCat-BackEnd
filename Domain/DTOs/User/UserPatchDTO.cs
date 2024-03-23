using System.ComponentModel.DataAnnotations;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserPatchDTO
{

    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

}