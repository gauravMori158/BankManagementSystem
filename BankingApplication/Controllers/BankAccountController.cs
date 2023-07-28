using BankingApplication.Interface;
using BankingApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BankingApplication.Controllers
{
    public class BankAccountController : Controller
    {
        private readonly IBankAccountRepo bankAccountRepo;
        public BankAccountController(IBankAccountRepo repo)
        {
                bankAccountRepo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var bankDetails =  await bankAccountRepo.GetAllAccounts();
            return View(bankDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //For Bank Account View
            ViewBag.AccountTypeId = new SelectList(await bankAccountRepo.GetAccountType(), "AccountTypeId", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BankAccount bankAccount)
        {
            bankAccountRepo.CreateAccount(bankAccount);

            //For Bank Account View
            ViewData["AccountTypeId"] = new SelectList(await bankAccountRepo.GetAccountType(), "AccountTypeId", "Name");

            return RedirectToAction("Index");
        }
    }
}
