using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InPay__CuriousCat_BackEnd.Domain.Models;

public class Phone : Entity
{
    public int Phones { get; set; }

    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
}