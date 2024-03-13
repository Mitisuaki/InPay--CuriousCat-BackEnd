using InPay__CuriousCat_BackEnd.Domain.Models.Enums;

namespace InPay__CuriousCat_BackEnd.Domain.Models;

public class VirtualCard : Card
{
    public int VinculatedCardNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public VirtualCard() : base()
    {

    }
}