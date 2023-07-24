using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class BankAccount
    {
        [Key]
        public int BankAccountId { get; set; }
        [Required]
        public string FirstName { get;}
        public string MiddleName{ get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [StringLength(8,MinimumLength =8,ErrorMessage ="Account Number Must Have 8 Digits")]
         
        public string AccountNumber { get; set; }
        [Required]
        public DateTime OpeningDate{ get; set; }
        public DateTime ClosingDate{ get; set; }
        [Required]
        public Decimal TotalBalance { get; set; }

        public AccountType AccountType { get; set; }



    }
}
