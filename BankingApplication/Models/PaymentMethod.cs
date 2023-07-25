using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class PaymentMethod
    {
        [Key]

        public int PaymentMethodId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
