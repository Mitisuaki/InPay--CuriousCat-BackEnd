using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;

namespace InPay__CuriousCat_BackEnd.Domain.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {

        CreateMap<UserCreateDTO, User>();
        CreateMap<User, UserCreateResponseDTO>();
        CreateMap<User, UserLoginResponseDTO>();
        CreateMap<User, UserGetInfoResponseDTO>()
        .ForMember(dest => dest.Accounts, options => options.MapFrom<List<Account>>(src =>
            src.Accounts!
        )); ;
        CreateMap<UserUpdateDTO, User>();
        CreateMap<UserUpdatePWDTO, User>();
    }
}