using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InPay__CuriousCat_BackEnd.Domain.Models;

public class Entity
{
    [Key]
    public int Id { get; set; }
}