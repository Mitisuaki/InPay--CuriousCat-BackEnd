using InPay__CuriousCat_BackEnd.Domain.Models.Enums;

namespace InPay__CuriousCat_BackEnd.Domain.Models;

public class Card
{
    public string CardNickName { get; set; } = null!;
    public int CardNumber { get; set; }
    public DateTime Expirationdate { get; set; }
    public string CVV { get; set; } = null!;
    public EnumFlags Flag { get; set; }
    public bool IsActive { get; set; }
    public bool IsBlocked { get; set; }
    public bool IsCreditEnabled { get; set; }
    public bool IsProximityEnabled { get; set; }
    public string CardPassword { get; set; } = null!;
    public Card()
    {

    }
}