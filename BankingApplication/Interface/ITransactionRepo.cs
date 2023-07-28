using BankingApplication.Models;

namespace BankingApplication.Interface
{
    public interface ITransactionRepo
    {
        Task<IList<PaymentMethod>> GetPaymentMethod();
        Task<int> TransactionCount();

        void AddTransaction(BankTransaction bankTransaction);
        void AddTransactionPosting(BankAccountPosting transactionPosting);

        Task<IList<BankTransaction>> GetBankTransactions();
        Task<IList<BankAccountPosting>>GetBankAccountPostings();

        void Save();
    }
}
