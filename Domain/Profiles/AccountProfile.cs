using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Account, AccFinanceDataResponseDTO>();
        CreateMap<Account, AccPFBasicDataResponseDTO>();
        CreateMap<Account, AccPJBasicDataResponseDTO>();
    }
}