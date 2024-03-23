using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.Services;

namespace InPay__CuriousCat_BackEnd.Domain.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {

        CreateMap<UserCreateDTO, User>();
        CreateMap<User, UserCreateResponseDTO>();
        CreateMap<User, UserLoginResponseDTO>();
        CreateMap<UserUpdateDTO, User>();
        CreateMap<UserUpdatePWDTO, User>();
    }
}