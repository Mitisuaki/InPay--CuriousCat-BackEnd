using InPay__CuriousCat_BackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InPay__CuriousCat_BackEnd.Domain;

public class AppDbContext : DbContext {
    
    public AppDbContext(DbContextOptions<AppDbContext> options) 
    :base(options) { }

    public DbSet<User> Users { get; set; }

}