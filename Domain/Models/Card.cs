using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InPay__CuriousCat_BackEnd.Domain.Models.Enums;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InPay__CuriousCat_BackEnd.Domain.Models;

public class Card
{
    [Key]
    public int CardNumber { get; set; }
    public string CardNickName { get; set; } = null!;
    public DateTime Expirationdate { get; set; }
    public string CVV { get; set; } = null!;
    public EnumFlags Flag { get; set; }
    public bool IsActive { get; set; }
    public bool IsBlocked { get; set; }
    public bool IsCreditEnabled { get; set; }
    public bool IsProximityEnabled { get; set; }
    public string HashCardPassword { get; set; } = null!;
    public bool IsVirtual { get; set; }
    public int VinculatedCardNumber { get; set; }

    [ForeignKey("AccId")]
    public virtual Card? VinculatedCard { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [ForeignKey("AccId")]
    public int AccId { get; set; }
    public virtual Account Account { get; set; } = null!;

}