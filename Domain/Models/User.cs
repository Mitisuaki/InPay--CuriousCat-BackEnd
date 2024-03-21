using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace InPay__CuriousCat_BackEnd.Domain.Models;


public class User : IdentityUser
{
    public string NickName { get; set; } = null!;
    public List<int> Phones { get; set; } = null!;
    public IAccount[]? Accounts { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }
    public bool IsAdmin { get; set; }
    public string RecoveryCode { get; set; } = null!;
}