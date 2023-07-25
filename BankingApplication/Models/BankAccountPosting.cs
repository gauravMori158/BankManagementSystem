using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApplication.Models
{
    public class BankAccountPosting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankAccountPostingId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Transactiontype{ get; set; }
        [Required]
        public string Category{ get; set; }
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,6})?$", ErrorMessage = "Amount should have up to 6 decimal places.")]
        public decimal Amount { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public PaymentMethod PaymentMethod { get; set; }
        [Required]
        public int PaymentMethodId { get; set; }
        [Required]
        public BankAccount BankAccount { get; set; }
        [Required]
        public int BankAccountId { get; set; }

        /*
Transaction Person First Name
Transaction Person Middle Name
Transaction Person Last Name
TransactionType => Credit or Debit
Category => Bank Interest, Bank Charges
Amount => upto 6 decimal places
TransactionDate
PaymentMethod_FK
BankAccount_FK
         */
    }
}
