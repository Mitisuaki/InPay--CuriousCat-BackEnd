using System.ComponentModel.DataAnnotations;

namespace InPay__CuriousCat_BackEnd.Domain
{
    public class SaldoContaPF
    {
       [Key] // Marca a propriedade como chave primária
        public int numero_conta { get; set; }
        public decimal saldo { get; set; }     
    }
    public class SaldoContaPJ
    {
        [Key] // Marca a propriedade como chave primária
        public int numero_conta { get; set; }
        public decimal saldo { get; set; }
    }
}
