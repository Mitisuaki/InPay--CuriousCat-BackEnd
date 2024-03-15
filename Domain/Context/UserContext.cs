using InPay__CuriousCat_BackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InPay__CuriousCat_BackEnd.Domain;

public class UserDbContext : DbContext {
    
    public UserDbContext(DbContextOptions<UserDbContext> options) 
    :base(options) { }

    public DbSet<User> Users { get; set; }

}