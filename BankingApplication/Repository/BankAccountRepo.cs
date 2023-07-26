using BankingApplication.Controllers;
using BankingApplication.Interface;
using BankingApplication.Models;
using BankingApplication.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace BankingApplication.Repository
{
    public class BankAccountRepo : IBankAccountRepo
    {
        
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public BankAccountRepo(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
                
        }

        public void CreateAccount(BankAccount bankAccount)
        {
                _context.BankAccount.Add(bankAccount);
                _context.SaveChanges();
        }

        public BankAccount GetAccount(int id)
        {
            var account = _context.BankAccount.Include(x => x.AccountType).FirstOrDefault(x=>x.BankAccountId == id);
            return account;
        }

        public IList<AccountType> GetAccountType()
        {
            var accountType = _context.AccountTypes.ToList();
            return accountType;
        }

        public IList<BankAccount> GetAllAccounts()
        {
            var accounts = _context.BankAccount.Include(x => x.AccountType).ToList();
            return accounts;
        }
    }
}
