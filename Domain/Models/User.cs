using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.Models;


public class User : Entity
{
    public int Id { get; set; }
    public string? NickName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public List<int>? Phones { get; set; }
    public IAccount[]? Accounts { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }
    public bool IsAdmin { get; set; }
    public string? RecoveryCode { get; set; }

    public User() { }
}