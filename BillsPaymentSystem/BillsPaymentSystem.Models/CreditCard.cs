namespace BillsPaymentSystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
 
    public class CreditCard : BillingDetails
    {
      
        public string CardType { get; set; }

        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
