using BankingApplication.Enums;
using BankingApplication.Models;
using BankingApplication.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BankingApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly  ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {

            _context = context;
            _logger = logger;
        }



        [HttpGet]
        public IActionResult MoneyTransfer()
        {
            ViewBag.PaymentMethodId = new SelectList(_context.PaymentMethod.ToList(), "PaymentMethodId", "Name");
            ViewBag.BankAccountId = new SelectList(_context.BankAccount.ToList(), "BankAccountId", "FirstName");

         
            return View();
        }
        [HttpPost]
        public IActionResult MoneyTransfer(BankTransaction bankTransaction)
        {
            
            ViewBag.BankAccountId = new SelectList(_context.BankAccount.ToList(), "BankAccountId", "FirstName");
            ViewBag.PaymentMethodId = new SelectList(_context.PaymentMethod.ToList(), "PaymentMethodId", "Name");
            _context.BankTransaction.Add(bankTransaction);
            var bankAccountId = bankTransaction.BankAccountId;
            var bankAccount = _context.BankAccount.Find(bankAccountId);

            // Implementation Pending

            bankAccount.TotalBalance += bankTransaction.Amount;

            _context.SaveChanges();


            return  RedirectToAction("TransactionDetails");

        }
        [HttpGet]
        public IActionResult TransactionDetails()
        {
            var transaction = _context.BankTransaction.Include(x => x.BankAccount).Include(x=>x.PaymentMethod).ToList();
            return View(transaction);  
        }
        public IActionResult Index()
        {
            var bankDetails = _context.BankAccount.Include(x=>x.AccountType).ToList();
            return View(bankDetails);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
             ViewBag.AccountTypeId = new SelectList(_context.AccountTypes.ToList(), "AccountTypeId", "Name");

            return View();
        }
        [HttpPost]
        public IActionResult Create(BankAccount bankAccount)
        {


            var dummy = _context.BankAccount.ToList();
            _context.BankAccount.Add(bankAccount);
            ViewData["AccountTypeId"] = new SelectList(dummy.Select(x=>x.AccountType), "AccountTypeId", "Name");

            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}