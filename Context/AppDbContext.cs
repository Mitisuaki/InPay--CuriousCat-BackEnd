using InPay__CuriousCat_BackEnd.Domain;
using Microsoft.EntityFrameworkCore;

namespace InPay__CuriousCat_BackEnd.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        //mapear as entidades
        public DbSet<SaldoContaPF> contas_pessoas_fisica { get; set; }
        public DbSet<SaldoContaPJ> contas_pessoas_juridica { get; set; }
    }
}
