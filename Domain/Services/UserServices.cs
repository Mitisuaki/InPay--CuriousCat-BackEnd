using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.Db;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;
using InPay__CuriousCat_BackEnd.Domain.Models;

namespace InPay__CuriousCat_BackEnd.Domain.Services;

public class UserServices(IMapper mapper, InpayDbContext dbContext)
{
    private readonly IMapper _mapper = mapper;
    private readonly InpayDbContext _dbContext = dbContext;

    public void DeleteUserRequest()
    {

    }
    public User CreateUser(UserCreateDTO user)
    {
        var userMapped = _mapper.Map<User>(user);

        return userMapped;

    }
    public void Login()
    {

    }
    public void Logoff()
    {

    }
    public void AddPhones()
    {

    }
    public void UpdatePhones()
    {

    }
    public void UpdateEmail()
    {

    }
    public void UpdateAccStatus()
    {

    }
    public void UpdateAdress()
    {

    }
    public void UpdatePassword()
    {

    }
    public void ForgotPassWord()
    {

    }
    public void GenUserLoginToken()
    {

    }
}