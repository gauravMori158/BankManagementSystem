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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>().HasData(
                new AccountType()
                {
                    AccountTypeId = 1,
                    Name = "Liability"
                },
               new AccountType()
               {
                   AccountTypeId = 2,
                   Name = "Asset"
               }
            );

            modelBuilder.Entity<PaymentMethod>().HasData
             (
                new PaymentMethod()
                {   
                    PaymentMethodId=1,
                    Name = "Cash"
                },
                new PaymentMethod()
                {
                    PaymentMethodId=2,
                    Name="Cheque"
                },
                new PaymentMethod()
                {
                    PaymentMethodId=3,
                    Name="NEFT"
                },
                new PaymentMethod()
                {
                    PaymentMethodId=4,
                    Name="RTGS"
                },
                new PaymentMethod()
                {
                    PaymentMethodId=5,
                    Name="Other"
                }
            );
        }





    }
}
