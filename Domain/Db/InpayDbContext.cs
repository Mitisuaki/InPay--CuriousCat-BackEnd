using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.Models.Enums;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InPay__CuriousCat_BackEnd.Domain.Db;

public class InpayDbContext : IdentityDbContext<User>
{
    public InpayDbContext(DbContextOptions<InpayDbContext> options)
    : base(options)
    {
    }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<AccTransaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AccTransaction>(
            transaction =>
            {
                transaction
                .HasOne(transaction => transaction.AccountToOrFrom)
                .WithMany(accout => accout.Transactions)
                .OnDelete(DeleteBehavior.Restrict);
            }
        );

        modelBuilder.Entity<User>()
        .HasIndex(user => user.Email)
        .IsUnique();

        modelBuilder.Entity<User>()
        .HasIndex(user => user.UserName)
        .IsUnique();
    }
}

