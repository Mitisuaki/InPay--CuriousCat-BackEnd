using System.ComponentModel.DataAnnotations;

namespace InPay__CuriousCat_BackEnd.Domain.Models;

public interface IEntity {
    public int id { get; set; }
}

public abstract class Entity : IEntity {
    
    [Key]
    [Required]
    public int id { get; set; }
}