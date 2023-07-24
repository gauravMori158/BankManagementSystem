using Microsoft.EntityFrameworkCore;

namespace BankingApplication.Models.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {
                
        }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<BankAccountPosting> BankAccountPosting { get; set; }
        public DbSet<BankTransaction> BankTransaction { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        
    }
}
