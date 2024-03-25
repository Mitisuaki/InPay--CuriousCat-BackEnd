using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Transactions;
using InPay__CuriousCat_BackEnd.Domain.Models;

namespace InPay__CuriousCat_BackEnd.Domain.Profiles;

public class AccTransactionProfile : Profile
{
    public AccTransactionProfile()
    {
        CreateMap<DepositCreationDTO, AccTransaction>();
        CreateMap<WithdrawCreationDTO, AccTransaction>();
        CreateMap<TransferRequestDTO, DepositRequestDTO>()
            .ForMember(dest => dest.AccNumber, opt => opt.MapFrom(src => src.AccToTransferNumber));
        CreateMap<TransferRequestDTO, WithdrawRequestDTO>();
    }
}