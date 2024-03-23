using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;
using InPay__CuriousCat_BackEnd.Domain.Models;

namespace InPay__CuriousCat_BackEnd.Domain.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {

        CreateMap<UserCreateDTO, User>();
        CreateMap<User, UserCreateResponseDTO>();
        CreateMap<User, UserLoginResponseDTO>();
        CreateMap<User, UserGetInfoResponseDTO>();
        CreateMap<UserUpdateDTO, User>();
        CreateMap<UserUpdatePWDTO, User>();
    }
}