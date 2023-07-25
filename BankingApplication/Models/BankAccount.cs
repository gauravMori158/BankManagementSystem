using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApplication.Models
{
    public class BankAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankAccountId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? MiddleName{ get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [StringLength(8,MinimumLength =8,ErrorMessage ="Account Number Must Have 8 Digits")]
         
        public string AccountNumber { get; set; }
        [Required]
        public DateTime OpeningDate{ get; set; }

        public DateTime? ClosingDate{ get; set; }
         
        public decimal TotalBalance { get; set; }
        [Required]
        public int AccountTypeId { get; set; }
        [Required]
        public AccountType AccountType { get; set; }




    }
}
