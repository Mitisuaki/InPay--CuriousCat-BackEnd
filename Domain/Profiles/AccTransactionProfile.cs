using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Transactions;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.Models.Enums;

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
        CreateMap<AccTransaction, AccDWTransactionsDTO>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => MapTypeEnum(src.Type, src.AccountToOrFromId)))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapStatusEnum(src.Status)));

        CreateMap<AccTransaction, AccTINransactionsDTO>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapStatusEnum(src.Status)))
            .ForMember(dest => dest.AccFromID, opt => opt.MapFrom(src => src.AccountToOrFromId));

        CreateMap<AccTransaction, AccTOUTransactionsDTO>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapStatusEnum(src.Status)))
            .ForMember(dest => dest.AccToID, opt => opt.MapFrom(src => src.AccountToOrFromId));
    }

    public string MapDirectionEnum(EnumTransactionDirection direction)
    {
        if (direction == EnumTransactionDirection.IN)
        {
            return "IN";
        }
        return "OUT";
    }
    public string MapTypeEnum(EnumTransactionType type, int? accFrom)
    {
        if (type == EnumTransactionType.DEPOSIT && accFrom is null)
        {
            return "DEPOSIT";
        }
        else if (type == EnumTransactionType.WITHDRAW && accFrom is null)
        {
            return "WITHDRAW";
        }

        return "TRANSFER";

    }
    public string MapStatusEnum(EnumTransactionStatus status)
    {
        if (status == EnumTransactionStatus.PROCESSING)
        {
            return "PROCESSING";
        }
        else if (status == EnumTransactionStatus.DENIED)
        {
            return "DENIED";
        }
        else if (status == EnumTransactionStatus.DONE)
        {
            return "DONE";
        }

        return "CANCELED";

    }
}