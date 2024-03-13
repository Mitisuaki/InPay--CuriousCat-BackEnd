using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Account;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<IAccount, AccFinanceDataResponseDTO>();
        CreateMap<AccPF, AccPFBasicDataResponseDTO>();
        CreateMap<AccPJ, AccPJBasicDataResponseDTO>();
    }
}