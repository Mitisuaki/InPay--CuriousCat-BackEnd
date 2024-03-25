using System.Text.Json.Serialization;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Transactions;
public class TransactionsResponseDTO(List<AccDWTransactionsDTO> mappedDWTransactions, AccTTransactionsDTO allTransfers)
{
    public virtual List<AccDWTransactionsDTO>? DepositsNWithDraws { get; set; } = mappedDWTransactions;
    public virtual AccTTransactionsDTO Transfers { get; set; } = allTransfers;
}