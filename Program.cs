using InPay__CuriousCat_BackEnd.Config;
using InPay__CuriousCat_BackEnd.Domain.Db;
using InPay__CuriousCat_BackEnd.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddDbContext<InpayDbContext>(options =>
{
    options
    .UseLazyLoadingProxies()
    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultDBConnection"));
});

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<InpayDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddSecurityLayer(builder.Configuration.GetValue<string>("AppSettings:TkSymKey")!);
builder.Services.AddServicesLayer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
