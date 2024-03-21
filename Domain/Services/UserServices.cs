using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;
using InPay__CuriousCat_BackEnd.Domain.Models;

namespace InPay__CuriousCat_BackEnd.Domain.Services;

public class UserServices(IMapper mapper)
{
    private readonly IMapper _mapper = mapper;

    public void DeleteUserRequest()
    {

    }
    public void CreateUser(UserCreateDTO user)
    {
        var userMapped = _mapper.Map<User>(user);


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