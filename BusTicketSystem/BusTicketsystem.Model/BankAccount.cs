namespace BusTicketsystem.Model
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class BankAccount
    {

        [ForeignKey("Customer")]
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
