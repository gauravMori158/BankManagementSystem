using BankingApplication.Models;

namespace BankingApplication.Interface
{
    public interface IBankAccountRepo
    {
        Task<IList<BankAccount>>GetAllAccounts();
        Task<BankAccount> GetAccount(int id);

        Task<IList<AccountType>> GetAccountType();

        Task CreateAccount(BankAccount bankAccount);

        
    }
}
