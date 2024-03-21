using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.Db;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;

namespace InPay__CuriousCat_BackEnd.Domain.Services;

public class UserServices(IMapper mapper, InpayDbContext dbContext)
{
    private readonly IMapper _mapper = mapper;
    private readonly InpayDbContext _dbContext = dbContext;

    public void DeleteUserRequest()
    {

    }
    public void CreateUser(UserCreateDTO user)
    {


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