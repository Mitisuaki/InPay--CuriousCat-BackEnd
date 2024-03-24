using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Adresses;
using InPay__CuriousCat_BackEnd.Domain.Models;

namespace InPay__CuriousCat_BackEnd.Domain.Profiles;

public class AdressesProfile : Profile
{
    public AdressesProfile()
    {
        CreateMap<AdressCreateDTO, Adress>().ReverseMap();
    }
}