using InPay__CuriousCat_BackEnd.Domain.Models.Enums;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Cards;

public class VirtualCardResponseDTO
{
    public int VinculatedCardNumber { get; set; }
    public string? CardNickName { get; set; }
    public int CardNumber { get; set; }
    public DateTime Expirationdate { get; set; }
    public string? CVV { get; set; }
    public EnumFlags Flag { get; set; }
    public bool IsBlocked { get; set; }
    public DateTime CreatedAt { get; set; }

}