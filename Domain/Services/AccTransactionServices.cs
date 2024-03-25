using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.Db;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Transactions;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;
using InPay__CuriousCat_BackEnd.Exceptions;

namespace InPay__CuriousCat_BackEnd.Domain.Services;

public class AccTransactionServices(IMapper mapper, InpayDbContext inpayDbContext)
{
    private readonly IMapper _mapper = mapper;
    private readonly InpayDbContext _inpayDbContext = inpayDbContext;
    public async Task Deposit(DepoistRequestDTO depositInfo)
    {
        if (depositInfo.CPF is null && depositInfo.CNPJ is null)
        {
            throw new BadHttpRequestException("Please provide the CPF of CNPJ value to the acc you want to deposit");
        }
        if (depositInfo.CPF is not null && depositInfo.CNPJ is not null)
        {
            throw new BadHttpRequestException("Please provide only CPF or CNPJ value to the acc you want to deposit");
        }


        Account acc = new();

        if (depositInfo.CPF is not null)
        {
            acc = this.GetAcc(depositInfo.AccNumber, depositInfo.Agency, "cpf", depositInfo.CPF);
        }
        if (depositInfo.CNPJ is not null)
        {
            acc = this.GetAcc(depositInfo.AccNumber, depositInfo.Agency, "cnpj", depositInfo.CNPJ);
        }

        acc.Balance += depositInfo.Value;

        _inpayDbContext.Accounts.Update(acc);

        DepositCreationDTO transaction = new(depositInfo.Value, acc.Id);
        AccTransaction transactionToSave = _mapper.Map<AccTransaction>(transaction);

        _inpayDbContext.Transactions.Add(transactionToSave);

        await _inpayDbContext.SaveChangesAsync();


    }
    public void CreateBoleto()
    {

    }
    public void PayBoleto()
    {

    }
    public void UpdateBalance()
    {

    }
    public Account GetAcc(int accNumber, string agency, string type, string cpfOrCnpj)
    {
        if (type == "cpf")
        {
            var getAccCpf = _inpayDbContext.Accounts.Where(acc => acc.AccNumber == accNumber && acc.Agency == agency && acc.CPF != null && acc.CPF == cpfOrCnpj);

            if (!getAccCpf.Any())
                throw new NotFoundException("There's no account that matches the infomed info, please check and try again");

            return getAccCpf.ToList()[0];
        }

        var getAccCnpj = _inpayDbContext.Accounts.Where(acc => acc.AccNumber == accNumber && acc.Agency == agency && acc.CNPJ != null && acc.CNPJ == cpfOrCnpj);

        if (!getAccCnpj.Any())
            throw new NotFoundException("There's no account that matches the infomed info, please check and try again");

        return getAccCnpj.ToList()[0];
    }
}