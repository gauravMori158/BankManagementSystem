using BankingApplication.Enums;
using BankingApplication.Interface;
using BankingApplication.Models;
using BankingApplication.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security;

namespace BankingApplication.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IBankAccountRepo bankAccountRepo;
        private readonly ITransactionRepo bankTransactionRepo;
        private readonly BankAccountPosting bankAccountPosting;

        public TransactionController(IConfiguration configuration,
                                     IBankAccountRepo bankAccRepo,
                                     ITransactionRepo bankTrRepo,
                                     BankAccountPosting bankAccountPosting)
        {
          
            _configuration = configuration;
            bankAccountRepo = bankAccRepo;
            bankTransactionRepo = bankTrRepo;
            this.bankAccountPosting = bankAccountPosting;
        }

        [HttpGet]
        public IActionResult MoneyTransfer()
        {
            var transactionLimits = Convert.ToInt32(_configuration["AppSettings:NumbersOfAccountTransaction"]);


            ViewBag.PaymentMethodId = new SelectList(bankTransactionRepo.GetPaymentMethod(), "PaymentMethodId", "Name");
            ViewBag.BankAccountId = new SelectList(bankAccountRepo.GetAllAccounts(), "BankAccountId", "FirstName");

            int AccountCount = bankTransactionRepo.TransactionCount();

            ViewBag.Flag = false;
            if (AccountCount >= transactionLimits)
                ViewBag.Flag = true;

            return View();
        }

       
        [HttpPost]
        public IActionResult MoneyTransfer(BankTransaction bankTransaction)
        {
            var TransactionLimits = Convert.ToInt32 (_configuration["AppSettings:NumbersOfAccountTransaction"]);

            // For Money Transaction View
            ViewBag.BankAccountId = new SelectList(bankAccountRepo.GetAllAccounts(), "BankAccountId", "FirstName");
            ViewBag.PaymentMethodId = new SelectList(bankTransactionRepo.GetPaymentMethod(), "PaymentMethodId", "Name");

            bankTransactionRepo.AddTransaction(bankTransaction);

            var bankAccountId = bankTransaction.BankAccountId;

            var bankAccount =  bankAccountRepo.GetAccount(bankAccountId);

             if(bankTransaction.TransactionType == TransactionType.Credit.GetHashCode().ToString())
                bankAccount.TotalBalance += bankTransaction.Amount;
             else if(bankTransaction.TransactionType == TransactionType.Debit.GetHashCode().ToString())
                bankAccount.TotalBalance -= bankTransaction.Amount;

               
            

            if (bankTransaction.Category == Category.Bank_Charges.GetHashCode().ToString() ||
                bankTransaction.Category == Category.Bank_Interest.GetHashCode().ToString())
            {
                bankAccountPosting.FirstName = bankTransaction.FirstName;
                bankAccountPosting.MiddleName= bankTransaction.MiddleName;
                bankAccountPosting.LastName = bankTransaction.LastName;
                bankAccountPosting.Transactiontype = bankTransaction.TransactionType;
                bankAccountPosting.Category= bankTransaction.Category;
                bankAccountPosting.Amount= bankTransaction.Amount;
                bankAccountPosting.PaymentMethod= bankTransaction.PaymentMethod;
                bankAccountPosting.PaymentMethodId= bankTransaction.PaymentMethodId;
                bankAccountPosting.BankAccount=bankTransaction.BankAccount;
                bankAccountPosting.BankAccountId=bankTransaction.BankAccountId;

                bankTransactionRepo.AddTransactionPosting(bankAccountPosting);
            }

            bankTransactionRepo.Save();


            return  RedirectToAction("TransactionDetails");

        }

        [HttpGet]
        public IActionResult TransactionDetails()
        {
            var transaction = bankTransactionRepo.GetBankTransactions();
            return View(transaction);
        }


        [HttpGet]
        public IActionResult Charges()
        {
            var ChargesList = bankTransactionRepo.GetBankAccountPostings();
            return View(ChargesList);
        }

    }
}