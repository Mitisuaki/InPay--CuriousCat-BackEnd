using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;
using InPay__CuriousCat_BackEnd.Domain.Models;
using Microsoft.AspNetCore.Identity;
using InPay__CuriousCat_BackEnd.Exceptions;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using InPay__CuriousCat_BackEnd.Domain.Db;

namespace InPay__CuriousCat_BackEnd.Domain.Services;

public class UserServices(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, InpayDbContext inpayDbContext)
{
    private readonly IMapper _mapper = mapper;
    private readonly UserManager<User> _userManager = userManager;
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly IConfiguration _configuration = configuration;
    private readonly InpayDbContext _inpayDbContext = inpayDbContext;

    public async Task<UserCreateResponseDTO> CreateUser(UserCreateDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var checkIfUserExists = await _userManager.FindByEmailAsync(user.Email!);
        if (checkIfUserExists != null)
            throw new AlreadyExistsException("This email already exists, please provide a new one");

        var checkIfEmailExists = await _userManager.FindByNameAsync(user.UserName!);
        if (checkIfEmailExists != null)
            throw new AlreadyExistsException("This userName already exists, please provide a new one");

        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded)
            throw new ServerProblemException("We encountered an error trying to create you user, please try again later");

        var userCreated = await _userManager.FindByEmailAsync(user.Email!);

        return _mapper.Map<UserCreateResponseDTO>(userCreated);

    }
    public async Task<UserLoginResponseDTO> LoginUser(UserLoginDTO userDto)
    {
        var userToLog = await _userManager.FindByEmailAsync(userDto.Email);

        if (userToLog == null || !userToLog.IsActive)
            throw new NotFoundException("User not found");


        var result = await _signInManager.PasswordSignInAsync(userToLog, userDto.PassWord, true, false);

        if (!result.Succeeded)
            throw new UnauthorizedAccessException("Unauthorized");


        var loginTk = this.GenUserLoginToken(userToLog);

        var userLogged = _mapper.Map<UserLoginResponseDTO>(userToLog);
        userLogged.UserToken = loginTk;

        return userLogged;
    }
    public async Task<UserGetInfoResponseDTO> GetUserInfoById(string Id)
    {

        var result = await _userManager.FindByIdAsync(Id);

        if (result == null || !result.IsActive)
            throw new NotFoundException("User not Found");


        return _mapper.Map<UserGetInfoResponseDTO>(result);
    }
    public async Task<UserGetInfoResponseDTO> GetUserBasicInfoById(string Id)
    {

        var result = await _userManager.FindByIdAsync(Id);

        if (result == null || !result.IsActive)
            throw new NotFoundException("User not Found");


        return _mapper.Map<UserGetInfoResponseDTO>(result);
    }
    public IEnumerable<UserCreateResponseDTO> ListAllUsers()
    {

        var users = _inpayDbContext.Users.Where(u => u.IsActive);

        var result = users.Select(_mapper.Map<UserCreateResponseDTO>);

        return result;

    }
    public async Task<UserCreateResponseDTO> PatchUser(string id, UserPatchDTO userPatchDTO)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null || !user.IsActive)
            throw new NotFoundException("User not Found");

        user.UserName = userPatchDTO.UserName ?? user.UserName;
        user.Email = userPatchDTO.Email ?? user.Email;
        user.PhoneNumber = userPatchDTO.PhoneNumber ?? user.PhoneNumber;
        user.UpdatedAt = DateTime.UtcNow;

        await _userManager.UpdateAsync(user);

        return _mapper.Map<UserCreateResponseDTO>(user);

    }
    public async Task<UserCreateResponseDTO> UpdateUser(string id, UserUpdateDTO userUpdateDTO)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null || !user.IsActive)
            throw new NotFoundException("User not Found");

        user.UserName = userUpdateDTO.UserName;
        user.Email = userUpdateDTO.Email;
        user.PhoneNumber = userUpdateDTO.PhoneNumber;
        user.UpdatedAt = DateTime.UtcNow;

        await _userManager.UpdateAsync(user);

        return _mapper.Map<UserCreateResponseDTO>(user);
    }
    public async Task UpdatePassword(string id, UserUpdatePWDTO userUpdatePWDTO)
    {
        var userToUpdatePW = await _userManager.FindByIdAsync(id);

        if (userToUpdatePW == null || !userToUpdatePW.IsActive)
            throw new NotFoundException("User not Found");

        var result = await _userManager.ChangePasswordAsync(userToUpdatePW, userUpdatePWDTO.CurrentPassword, userUpdatePWDTO.NewPassword);

        if (!result.Succeeded)
            throw new BadHttpRequestException("User current password doesn't match");

    }
    public async Task ForgotPassWord(string id, UserForgotPWDTO userForgotPWDTO)
    {
        var userToResetPW = await _userManager.FindByIdAsync(id);

        if (userToResetPW == null || !userToResetPW.IsActive)
            throw new NotFoundException("User not Found");

        if (userToResetPW.RecoveryCode != userForgotPWDTO.RecoveryCode)
        {
            throw new BadHttpRequestException("User RecoveryCode doesn't match ");
        }

        var resultRemovePW = await _userManager.RemovePasswordAsync(userToResetPW);
        var resultAddNewPW = await _userManager.AddPasswordAsync(userToResetPW, userForgotPWDTO.NewPassword);


        if (!resultRemovePW.Succeeded || !resultAddNewPW.Succeeded)
            throw new ServerProblemException("We encountered an error trying to set your new password, please try again later");

    }
    public async Task DeactivateUser(string id)
    {
        var userToDeactivate = await _userManager.FindByIdAsync(id);

        if (userToDeactivate == null)
            throw new NotFoundException("User not Found");
        if (!userToDeactivate.IsActive)
            throw new BadHttpRequestException("User Already Deactivated");

        userToDeactivate.IsActive = false;

        var result = await _userManager.UpdateAsync(userToDeactivate);

        if (!result.Succeeded)
            throw new ServerProblemException("We encountered an error trying to delete this user account, please try again later");
    }
    public async Task ReactivateUser(string id)
    {
        var userToReactivate = await _userManager.FindByIdAsync(id);

        if (userToReactivate == null)
            throw new NotFoundException("User not Found");
        if (userToReactivate.IsActive)
            throw new BadHttpRequestException("User Already Active");

        userToReactivate.IsActive = true;

        var result = await _userManager.UpdateAsync(userToReactivate);

        if (!result.Succeeded)
            throw new ServerProblemException("We encountered an error trying undelete this user account, please try again later");
    }
    public string GenUserLoginToken(User user)
    {
        Claim[] claims = [
            new("Username", user.UserName!),
            new("Id", user.Id),
            new("IsAdmin", user.IsAdmin.ToString())
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