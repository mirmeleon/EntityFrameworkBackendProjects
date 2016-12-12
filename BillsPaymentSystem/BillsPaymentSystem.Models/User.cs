

using System.Collections.Generic;

namespace BillsPaymentSystem.Models
{
    public class User
    {
        private ICollection<BillingDetails> billingDetails;

        public User()
        {

            this.BankAccount = new HashSet<BankAccount>();
            this.CreditCard = new HashSet<CreditCard>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<BankAccount> BankAccount { get; set; }
        public virtual ICollection<CreditCard> CreditCard { get; set; }

    }
}
