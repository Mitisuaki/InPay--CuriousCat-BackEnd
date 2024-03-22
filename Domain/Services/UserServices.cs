using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;
using InPay__CuriousCat_BackEnd.Domain.Models;
using Microsoft.AspNetCore.Identity;
using InPay__CuriousCat_BackEnd.Exceptions;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace InPay__CuriousCat_BackEnd.Domain.Services;

public class UserServices(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
{
    private readonly IMapper _mapper = mapper;
    private readonly UserManager<User> _userManager = userManager;
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly IConfiguration _configuration = configuration;

    public async Task<UserCreateResponseDTO> CreateUser(UserCreateDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded)
            throw new Exception(result.Errors.ToString());

        var userCreated = await _userManager.FindByEmailAsync(user.Email!);

        return _mapper.Map<UserCreateResponseDTO>(userCreated);

    }
    public async Task<UserCreateResponseDTO> GetUserInfoById(string Id)
    {
        var result = await _userManager.FindByIdAsync(Id);

        if (result == null)
            throw new NotFoundException("User not Found");


        return _mapper.Map<UserCreateResponseDTO>(result);
    }
    public async Task<UserLoginResponseDTO> LoginUser(UserLoginDTO userDto)
    {
        var userToLog = await _userManager.FindByEmailAsync(userDto.Email);

        if (userToLog == null)
            throw new NotFoundException("User not found");


        var result = await _signInManager.PasswordSignInAsync(userToLog, userDto.PassWord, true, false);

        if (!result.Succeeded)
            throw new UnauthorizedAccessException("Unauthorized");


        var loginTk = this.GenUserLoginToken(userToLog);

        var userLogged = _mapper.Map<UserLoginResponseDTO>(userToLog);
        userLogged.UserToken = loginTk;

        return userLogged;
    }
    public void DeactivateUser()
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
    public string GenUserLoginToken(User user)
    {
        Claim[] claims = [
            new("Username", user.UserName!),
            new("Id", user.Id),
            new("LoginTimeStamp", DateTime.UtcNow.ToString())
        ];

        var tkSymKey = _configuration.GetValue<string>("AppSettings:TkSymKey");

        if (tkSymKey == null)
            throw new InvalidSymmetricKeyException("Invalid Symmetric Key to create Token");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tkSymKey));

        var loginCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: loginCredentials,
            claims: claims
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}