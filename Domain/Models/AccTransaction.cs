using System.ComponentModel.DataAnnotations.Schema;
using InPay__CuriousCat_BackEnd.Domain.Models.Enums;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.Models;

public class AccTransaction : Entity
{
    public EnumTransactionDirection Direction { get; set; }
    public EnumTransactionType Type { get; set; }
    public EnumTransactionStatus Status { get; set; }
    public int Date { get; set; }
    public int Value { get; set; }

    [ForeignKey("AccountId")]
    public int AccountId { get; set; }
    public virtual Account? Account { get; set; }

    [ForeignKey("AccountToOrFromId")]
    public int? AccountToOrFromId { get; set; }
    public virtual Account? AccountToOrFrom { get; set; }

}

