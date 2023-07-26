using BankingApplication.Models;

namespace BankingApplication.Interface
{
    public interface IBankAccountRepo
    {
        IList<BankAccount> GetAllAccounts();
        BankAccount GetAccount(int id);

        IList<AccountType> GetAccountType();

        void CreateAccount(BankAccount bankAccount);

        
    }
}
