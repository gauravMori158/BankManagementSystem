using BankingApplication.Models;

namespace BankingApplication.Interface
{
    public interface IBankAccountRepo
    {
        Task<IList<BankAccount>>GetAllAccounts();
        Task<BankAccount> GetAccount(int id);

        Task<IList<AccountType>> GetAccountType();

        void CreateAccount(BankAccount bankAccount);

        
    }
}
