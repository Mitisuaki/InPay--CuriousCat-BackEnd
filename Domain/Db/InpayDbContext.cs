using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InPay__CuriousCat_BackEnd.Domain.Db;

public class InpayDbContext : DbContext
{
    public InpayDbContext(DbContextOptions<InpayDbContext> options)
    : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<AccTransaction> Transactions { get; set; }

}

