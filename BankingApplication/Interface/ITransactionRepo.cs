using BankingApplication.Models;

namespace BankingApplication.Interface
{
    public interface ITransactionRepo
    {
        IList<PaymentMethod> GetPaymentMethod();
        int TransactionCount();

        void AddTransaction(BankTransaction bankTransaction);
        void AddTransactionPosting(BankAccountPosting transactionPosting);

        IList<BankTransaction> GetBankTransactions();
        IList<BankAccountPosting>GetBankAccountPostings();

        void Save();
    }
}
