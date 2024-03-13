using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Cards;
using InPay__CuriousCat_BackEnd.Domain.Models;

namespace InPay__CuriousCat_BackEnd.Domain.Profiles;

public class CardsProfile : Profile
{
    public CardsProfile()
    {
        CreateMap<Card, CardResponseDTO>();
        CreateMap<VirtualCard, VirtualCardResponseDTO>();
    }
}