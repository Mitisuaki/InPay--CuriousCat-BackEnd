namespace InPay__CuriousCat_BackEnd.Domain.Profiles;

using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;
using InPay__CuriousCat_BackEnd.Domain.Models;


public class UserProfile : Profile
{
    public UserProfile() {

        CreateMap<UserResponseDTO, User>();
        CreateMap<UserUpdateDTO, User>();
        CreateMap<UserUpdatePWDTO, User>();
    }
}