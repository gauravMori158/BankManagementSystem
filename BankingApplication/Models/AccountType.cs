using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class AccountType
    {
        [Key]
        [Required]
        public int AccountTypeId { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
