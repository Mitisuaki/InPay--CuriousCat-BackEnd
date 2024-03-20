using System.ComponentModel.DataAnnotations;

namespace InPay__CuriousCat_BackEnd.Domain
{
    public class RealizaTransacaoPGT
    {
        [Key] // Marca a propriedade como chave primária
        public int numerocontapf_origem { get; set; }             
        public int tipotransacao { get; set; }      
        public decimal valor { get; set; }        
    }
        public class RealizaTransacaoPFPF
    {
        [Key] // Marca a propriedade como chave primária
        public int numerocontapf_origem { get; set; }
        public int numerocontapf_destino { get; set; }
        public int tipotransacao { get; set; }        
        public decimal valor { get; set; }        
    }
    public class RealizaTransacaoPFPJ
    {
        [Key] // Marca a propriedade como chave primária
        public int numerocontapf_origem { get; set; }
        public int numerocontapj_destino { get; set; }
        public int tipotransacao { get; set; }        
        public decimal valor { get; set; }        
    }
    public class RealizaTransacaoPJPGT
    {
        [Key] // Marca a propriedade como chave primária
        public int numerocontapj_origem { get; set; }        
        public int tipotransacao { get; set; }        
        public decimal valor { get; set; }        
    }
    public class RealizaTransacaoPJPJ
    {
        [Key] // Marca a propriedade como chave primária
        public int numerocontapj_origem { get; set; }
        public int numerocontapj_destino { get; set; }
        public int tipotransacao { get; set; }        
        public decimal valor { get; set; }      
    }
    public class RealizaTransacaoPJPF
    {
        [Key] // Marca a propriedade como chave primária
        public int numerocontapj_origem { get; set; }
        public int numerocontapf_destino { get; set; }
        public int tipotransacao { get; set; }        
        public decimal valor { get; set; }        
    }
    public class RealizaTransacaoPJREC
    {
        [Key] // Marca a propriedade como chave primária
        public int numerocontapj_origem { get; set; }        
        public int tipotransacao { get; set; }
        public decimal valor { get; set; }
    }
    public class RealizaTransacaoPFREC
    {
        [Key] // Marca a propriedade como chave primária
        public int numerocontapf_origem { get; set; }
        public int tipotransacao { get; set; }
        public decimal valor { get; set; }
    }
}
