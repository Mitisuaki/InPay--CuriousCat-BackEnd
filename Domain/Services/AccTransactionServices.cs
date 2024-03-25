using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.Db;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Transactions;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.Models.Enums;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;
using InPay__CuriousCat_BackEnd.Exceptions;

namespace InPay__CuriousCat_BackEnd.Domain.Services;

public class AccTransactionServices(IMapper mapper, InpayDbContext inpayDbContext, AccountServices accService)
{
    private readonly IMapper _mapper = mapper;
    private readonly InpayDbContext _inpayDbContext = inpayDbContext;

    private readonly AccountServices _accService = accService;
    public async Task Deposit(DepositRequestDTO depositInfo, int? fromAccID = 0)
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

        if (fromAccID != 0)
        {
            transactionToSave.AccountToOrFromId = fromAccID;
        }

        _inpayDbContext.Transactions.Add(transactionToSave);

        await _inpayDbContext.SaveChangesAsync();


    }
    public async Task<double> Withdraw(AccTokenVerificationResponseDTO claims, WithdrawRequestDTO withdrawRequestDTO, TransferRequestDTO? transferRequestDTO = null)
    {
        Account acc = this.GetAcc(claims);

        if (acc.TransactionLimit < withdrawRequestDTO.Value)
        {
            throw new BadHttpRequestException($"This acc can't complete this transaction because it's value is higher than the transction limited setted for this acc, please do a lower transaction value or contact us to help you. \n The current transaction limit is R${acc.TransactionLimit}");
        }

        double currentBalance = acc.Balance;

        if (currentBalance < withdrawRequestDTO.Value)
        {
            throw new BadHttpRequestException($"This acc doesn't have enough funds to do this withdraw. The current balance is R${currentBalance}");
        }

        acc.Balance -= withdrawRequestDTO.Value;

        _inpayDbContext.Accounts.Update(acc);

        WithdrawCreationDTO transaction = new(withdrawRequestDTO.Value, acc.Id);
        AccTransaction transactionToSave = _mapper.Map<AccTransaction>(transaction);

        if (transferRequestDTO != null)
        {
            Account accTo = new();

            if (transferRequestDTO.CPF is not null)
            {
                accTo = this.GetAcc(transferRequestDTO.AccToTransferNumber, transferRequestDTO.Agency, "cpf", transferRequestDTO.CPF);
            }
            if (transferRequestDTO.CNPJ is not null)
            {
                accTo = this.GetAcc(transferRequestDTO.AccToTransferNumber, transferRequestDTO.Agency, "cnpj", transferRequestDTO.CNPJ);
            }

            transactionToSave.AccountToOrFromId = accTo.Id;
        }

        _inpayDbContext.Transactions.Add(transactionToSave);

        await _inpayDbContext.SaveChangesAsync();

        return acc.Balance;

    }
    public async Task Transfer(AccTokenVerificationResponseDTO claims, TransferRequestDTO transferRequestDTO)
    {


        await Withdraw(claims, _mapper.Map<WithdrawRequestDTO>(transferRequestDTO), transferRequestDTO);

        await Deposit(_mapper.Map<DepositRequestDTO>(transferRequestDTO), int.Parse(claims.AccId));
    }

    public TransactionsResponseDTO ListAllTransactions(AccTokenVerificationResponseDTO claims)
    {
        int accId = int.Parse(claims.AccId);

        List<AccTransaction> accDW = _inpayDbContext.Transactions.Where(transaction => transaction.AccountId == accId
                                                && transaction.AccountToOrFromId == null)
                                               .ToList();
        List<AccTransaction> accTIN = _inpayDbContext.Transactions.Where(transaction => transaction.AccountId == accId
                                                && transaction.Direction == EnumTransactionDirection.IN
                                                && transaction.AccountToOrFromId != null)
                                               .ToList();
        List<AccTransaction> accTOUT = _inpayDbContext.Transactions.Where(transaction => transaction.AccountId == accId
                                                && transaction.Direction == EnumTransactionDirection.OUT
                                                && transaction.AccountToOrFromId != null)
                                               .ToList();


        List<AccDWTransactionsDTO> mappedDWTransactions = _mapper.Map<List<AccDWTransactionsDTO>>(accDW) ?? [];
        List<AccTINransactionsDTO> mappedTINTransactions = _mapper.Map<List<AccTINransactionsDTO>>(accTIN) ?? [];
        List<AccTOUTransactionsDTO> mappedTOUTransactions = _mapper.Map<List<AccTOUTransactionsDTO>>(accTOUT) ?? [];


        AccTTransactionsDTO allTransfers = new(mappedTINTransactions, mappedTOUTransactions);
        TransactionsResponseDTO allTransactions = new(mappedDWTransactions, allTransfers);

        return allTransactions;

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
    public Account GetAcc(AccTokenVerificationResponseDTO claim)
    {

        var getAcc = _inpayDbContext.Accounts.Where(acc => acc.AccNumber == int.Parse(claim.AccNumber) && acc.UserId == claim.UserId && acc.Id == int.Parse(claim.AccId));

        if (!getAcc.Any())
            throw new NotFoundException("There's no account that matches the infomed info, please check and try again");

        return getAcc.ToList()[0];
    }
}