namespace InPay__CuriousCat_BackEnd.Domain.Models;

using System.ComponentModel.DataAnnotations;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

public class User : Entity
{
    public string? NickName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public List<int>? Phones { get; set; }
    public IAccount[]? Accounts { get; set; }


    [DisplayFormat(DataFormatString	="{0:dd-MM-yyyy}")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [DisplayFormat(DataFormatString	="{0:dd-MM-yyyy}")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public bool IsActive { get; set; }
    public bool IsAdmin { get; set; }
    public string? RecoveryCode { get; set; }

    public User() { }
}