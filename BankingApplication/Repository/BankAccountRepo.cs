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

        public async Task CreateAccount(BankAccount bankAccount)
        {
               await _context.BankAccount.AddAsync(bankAccount);
               await _context.SaveChangesAsync();
        }

        public async Task<BankAccount> GetAccount(int id)
        {
            var account = await _context.BankAccount.Include(x => x.AccountType).FirstOrDefaultAsync(x=>x.BankAccountId == id);
            return  account;
        }

        public async  Task<IList<AccountType>> GetAccountType()
        {
            var accountType = await _context.AccountTypes.ToListAsync();
            return accountType;
        }

        public async Task<IList<BankAccount>> GetAllAccounts()
        {
            var accounts =await _context.BankAccount.Include(x => x.AccountType).ToListAsync();
            return accounts;
        }
    }
}
