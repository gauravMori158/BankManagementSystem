using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApplication.Models
{
    public class AccountType
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountTypeId { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<BankAccount>  BankAccount { get; set; }

    }
}
