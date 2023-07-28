using BankingApplication.Interface;
using BankingApplication.Models;
using BankingApplication.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace BankingApplication.Repository
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepo(ApplicationDbContext context)
        {
                _context = context;
        }

        public async void AddTransaction(BankTransaction bankTransaction)
        {
            await _context.BankTransaction.AddAsync(bankTransaction);
  //          _context.SaveChanges();
        }

        public async void AddTransactionPosting(BankAccountPosting transactionPosting)
        {
            await _context.BankAccountPosting.AddAsync(transactionPosting);
  //          _context.SaveChanges();
        }

        public async Task<IList<PaymentMethod>> GetPaymentMethod()
        {
             var paymentMethod = await _context.PaymentMethod.ToListAsync();
             return paymentMethod; 
        }

        public async Task<int> TransactionCount()
        {
            return await _context.BankTransaction.CountAsync();
        }

        public  async void Save()
        {
              _context.SaveChanges(); 
        }

        public async Task<IList<BankTransaction>> GetBankTransactions()
        {
            var transaction = await _context.BankTransaction.Include(x => x.BankAccount).Include(x => x.PaymentMethod).ToListAsync();
            return transaction;
        }

        public async Task<IList<BankAccountPosting>> GetBankAccountPostings()
        {
            var ChargesList = await _context.BankAccountPosting.Include(x => x.BankAccount).Include(x => x.PaymentMethod).ToListAsync();
            return ChargesList;
        }
    }
}
