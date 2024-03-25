using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.Db;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;
using InPay__CuriousCat_BackEnd.Exceptions;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;

namespace InPay__CuriousCat_BackEnd.Domain.Services;

public class AccountServices(IMapper mapper, IConfiguration configuration, InpayDbContext inpayDbContext)
{
    private readonly IMapper _mapper = mapper;
    private readonly IConfiguration _configuration = configuration;
    private readonly InpayDbContext _inpayDbContext = inpayDbContext;
    public async Task<AccPFCreateResponseDTO> CreateAcc(AccPFCreateDTO accDto, string id)
    {
        var account = _mapper.Map<Account>(accDto);
        var adress = _mapper.Map<Adress>(accDto.Adress);


        var checkIfCPFExists = _inpayDbContext.Accounts.Where(acc => acc.CPF == accDto.CPF);
        if (checkIfCPFExists.Any())
            throw new AlreadyExistsException("An acc with this CPF already exists");

        account.UserId = id;

        var addAcc = await _inpayDbContext.Accounts.AddAsync(account);
        _inpayDbContext.SaveChanges();
        var entity = addAcc.Entity;

        adress.AccountId = entity.Id;
        var addAdress = await _inpayDbContext.Adresses.AddAsync(adress);
        await _inpayDbContext.SaveChangesAsync();

        var result = _mapper.Map<AccPFCreateResponseDTO>(entity);

        return result;

    }
    public async Task<AccPJCreateResponseDTO> CreateAcc(AccPJCreateDTO accDto, string id)
    {
        var account = _mapper.Map<Account>(accDto);
        Adress adress = _mapper.Map<Adress>(accDto.Adress);

        var checkIfCNPJExists = _inpayDbContext.Accounts.Where(acc => acc.CNPJ == accDto.CNPJ);
        if (checkIfCNPJExists.Any())
            throw new AlreadyExistsException("An acc with this CNPJ already exists");

        var checkIfCompanyNameExists = _inpayDbContext.Accounts.Where(acc => acc.CompanyName == accDto.CompanyName);
        if (checkIfCompanyNameExists.Any())
            throw new AlreadyExistsException("An acc with this CompanyName already exists");

        var checkIfCompanyEmailExists = _inpayDbContext.Accounts.Where(acc => acc.CompanyEmail == accDto.CompanyEmail);
        if (checkIfCompanyEmailExists.Any())
            throw new AlreadyExistsException("An acc with this Email already exists");

        var hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(accDto.Password!);

        account.HashPasswordPJ = hashedPassword;
        account.UserId = id;

        var addAcc = await _inpayDbContext.Accounts.AddAsync(account);
        await _inpayDbContext.SaveChangesAsync();
        var entity = addAcc.Entity;

        adress.AccountId = entity.Id;
        var addAdress = await _inpayDbContext.Adresses.AddAsync(adress);
        await _inpayDbContext.SaveChangesAsync();


        var result = _mapper.Map<AccPJCreateResponseDTO>(entity);

        return result;

    }
    public string Login(AccLoginDTO accLoginDTO, string userId, UserTokenVerificationResponseDTO tokenClaims)
    {
        var checkAccExists = _inpayDbContext.Accounts.Where(acc => (acc.AccNumber == accLoginDTO.AccNumber) && acc.UserId == userId);

        if (!checkAccExists.Any())
        {
            throw new NotFoundException("Please check you acc number, because no acc with this acc number was found associated to your user");
        }

        Claim[] claims = [
            new("UserId", userId),
            new("AccId", checkAccExists.ToList()[0].Id.ToString()!),
            new("AccNumber", accLoginDTO.AccNumber.ToString())
        ];

        string newToken = this.GenAccAPIToken(claims);

        return newToken;

    }
    public void Logoff()
    {

    }
    public void CheckCEP()
    {

    }
    public void UpdateAccLimit()
    {

    }
    public void UpdateAvailableLimit()
    {

    }
    public void UpdateConfiguredLimit()
    {

    }
    public void UpdateTransactionLimit()
    {

    }
    public double GetBalance(AccTokenVerificationResponseDTO accData)
    {
        var account = _inpayDbContext.Accounts.Where(acc => acc.Id == int.Parse(accData.AccId) && acc.AccNumber == int.Parse(accData.AccNumber) && acc.UserId == accData.UserId);
        var balance = account.ToList()[0].Balance;

        return balance;
    }
    public void UpdateBalance()
    {

    }
    public void UpdateNickName()
    {

    }
    public void UpdateEmail()
    {

    }
    public void UpdateCurrentAdress()
    {

    }
    public void ValidateCPF_CNPJ()
    {

    }
    public void GetTransactions()
    {

    }
    public void DeleteAccRequest()
    {

    }
    public void GenAccLoginToken()
    {

    }
    public string GenAccAPIToken(Claim[] claims)
    {

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