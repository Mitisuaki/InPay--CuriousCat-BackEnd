using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;
using Microsoft.AspNetCore.DataProtection;

namespace InPay__CuriousCat_BackEnd.Domain.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Account, AccFinanceDataResponseDTO>();
        CreateMap<Account, AccPFBasicDataResponseDTO>();
        CreateMap<Account, AccPJBasicDataResponseDTO>();
        CreateMap<Account, AccBasicDataResponseDTO>();
        CreateMap<AccPFCreateDTO, Account>()
        .AfterMap((accDto, acc) =>
        {
            acc.AccType = Models.Enums.EnumAccType.PESSOA_FISICA;
            acc.AccNumber = new Random().Next(1000, 5000);
        });
        CreateMap<AccPJCreateDTO, Account>()
        .AfterMap((accDto, acc) =>
        {
            acc.AccType = Models.Enums.EnumAccType.PESSOA_JURIDICA;
            acc.AccNumber = new Random().Next(5000, 10000);
        });
        CreateMap<Account, AccPFCreateResponseDTO>()
        .ForMember(dest => dest.CurrentAdress, options => options.MapFrom<Adress>(src =>
            src.AdressesHistory!.First(adress => adress.IsCurrentAdress)
        ));

        CreateMap<Account, AccPJCreateResponseDTO>()
        .ForMember(dest => dest.CurrentAdress, options => options.MapFrom<Adress>(src =>
            src.AdressesHistory!.First(adress => adress.IsCurrentAdress)
        ));
    }
}