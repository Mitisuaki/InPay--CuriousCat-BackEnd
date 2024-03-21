using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace InPay__CuriousCat_BackEnd.Domain.Db;

public class InpayDbContext : DbContext
{
    public InpayDbContext(DbContextOptions<InpayDbContext> options)
    : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<AccPF> AccountsPF { get; set; }
    public DbSet<AccPJ> AccountsPJ { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<VirtualCard> VirtualCards { get; set; }
    public DbSet<AccTransaction> Transactions { get; set; }

}