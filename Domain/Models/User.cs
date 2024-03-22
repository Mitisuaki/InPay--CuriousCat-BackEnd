using System.ComponentModel.DataAnnotations.Schema;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace InPay__CuriousCat_BackEnd.Domain.Models;


public class User : IdentityUser
{
    public virtual List<Account>? Accounts { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public bool IsAdmin { get; set; } = false;
    public string RecoveryCode { get; set; } = null!;
    public string AntiPishingCode { get; set; } = null!;
}
