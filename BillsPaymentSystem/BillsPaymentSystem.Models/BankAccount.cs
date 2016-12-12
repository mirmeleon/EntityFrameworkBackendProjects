namespace BillsPaymentSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class BankAccount : BillingDetails
    {
        [Required]
       public string BankName { get; set; }

        public string SwiftCode { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
