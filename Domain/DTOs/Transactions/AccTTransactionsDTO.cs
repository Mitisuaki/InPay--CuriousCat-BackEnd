
using System.Text.Json.Serialization;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.Transactions;
public class AccTTransactionsDTO(List<AccTINransactionsDTO> mappedTINTransactions, List<AccTOUTransactionsDTO> mappedTOUTransactions)
{
    public virtual List<AccTINransactionsDTO> ReceivedTranfers { get; set; } = mappedTINTransactions;
    public virtual List<AccTOUTransactionsDTO> SentTransfers { get; set; } = mappedTOUTransactions;

}