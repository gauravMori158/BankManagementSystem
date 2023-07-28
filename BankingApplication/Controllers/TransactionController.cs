using AutoMapper;
using BankingApplication.Enums;
using BankingApplication.Interface;
using BankingApplication.Models;
using BankingApplication.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections;
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
        private readonly IMapper _mapper;

        public TransactionController(IConfiguration configuration,
                                     IBankAccountRepo bankAccRepo,
                                     ITransactionRepo bankTrRepo,
                                     BankAccountPosting bankAccountPosting,
                                     IMapper mapper)
        {
          
            _configuration = configuration;
            bankAccountRepo = bankAccRepo;
            bankTransactionRepo = bankTrRepo;
            this.bankAccountPosting = bankAccountPosting;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> MoneyTransfer()
        {
            var transactionLimits = Convert.ToInt32(_configuration["AppSettings:NumbersOfAccountTransaction"]);


            ViewBag.PaymentMethodId =  new SelectList(await bankTransactionRepo.GetPaymentMethod(), "PaymentMethodId", "Name");
            ViewBag.BankAccountId = new SelectList(await bankAccountRepo.GetAllAccounts(), "BankAccountId", "FirstName");

            int AccountCount = await bankTransactionRepo.TransactionCount();

            ViewBag.Flag = false;
            if (AccountCount >= transactionLimits)
                ViewBag.Flag = true;

            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> MoneyTransfer(BankTransaction bankTransaction)
        {
            var TransactionLimits = Convert.ToInt32 (_configuration["AppSettings:NumbersOfAccountTransaction"]);

            // For Money Transaction View
            ViewBag.BankAccountId = new SelectList( await bankAccountRepo.GetAllAccounts(), "BankAccountId", "FirstName");
            ViewBag.PaymentMethodId = new SelectList(await bankTransactionRepo.GetPaymentMethod(), "PaymentMethodId", "Name");

            bankTransactionRepo.AddTransaction(bankTransaction);

            var bankAccountId = bankTransaction.BankAccountId;

            var bankAccount =  await bankAccountRepo.GetAccount(bankAccountId);

             if(bankTransaction.TransactionType == TransactionType.Credit.GetHashCode().ToString())
                bankAccount.TotalBalance += bankTransaction.Amount;
             else if(bankTransaction.TransactionType == TransactionType.Debit.GetHashCode().ToString())
                bankAccount.TotalBalance -= bankTransaction.Amount;

               
            

            if (bankTransaction.Category == Category.Bank_Charges.GetHashCode().ToString() ||
                bankTransaction.Category == Category.Bank_Interest.GetHashCode().ToString())
            {
                var accpuntPosting = _mapper.Map<BankAccountPosting>(bankTransaction);

                bankTransactionRepo.AddTransactionPosting(accpuntPosting);
            }
            //Create Trigger On Insert on Table Bank Transaction 

            bankTransactionRepo.Save();


            return  RedirectToAction("TransactionDetails");

        }

        [HttpGet]
        public async Task<IActionResult> TransactionDetails()
        {
            var transaction = await bankTransactionRepo.GetBankTransactions();

            return View(transaction);
        }


        [HttpGet]
        public async Task<IActionResult> Charges()
        {
            var ChargesList = await bankTransactionRepo.GetBankAccountPostings();
            return View(ChargesList);
        }

    }
}