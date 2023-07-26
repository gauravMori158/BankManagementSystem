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

        public void AddTransaction(BankTransaction bankTransaction)
        {
            _context.BankTransaction.Add(bankTransaction);
  //          _context.SaveChanges();
        }

        public void AddTransactionPosting(BankAccountPosting transactionPosting)
        {
            _context.BankAccountPosting.Add(transactionPosting);
  //          _context.SaveChanges();
        }

        public IList<PaymentMethod> GetPaymentMethod()
        {
             var paymentMethod = _context.PaymentMethod.ToList();
             return paymentMethod; 
        }

        public int TransactionCount()
        {
            return _context.BankTransaction.Count();
        }

        public void Save()
        {
            _context.SaveChanges(); 
        }

        public IList<BankTransaction> GetBankTransactions()
        {
            var transaction = _context.BankTransaction.Include(x => x.BankAccount).Include(x => x.PaymentMethod).ToList();
            return transaction;
        }

        public IList<BankAccountPosting> GetBankAccountPostings()
        {
            var ChargesList = _context.BankAccountPosting.Include(x => x.BankAccount).Include(x => x.PaymentMethod).ToList();
            return ChargesList;
        }
    }
}
