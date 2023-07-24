using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class PaymentMethod
    {
        [Key]
        [Required]
        public int PaymentMethodId { get; set; }
        [Required]
        public string Name{ get; set; }
    }
}
