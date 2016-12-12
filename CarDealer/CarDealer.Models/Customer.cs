namespace CarDealer.Models
{
    using System;
    using System.Collections.Generic;
    public class Customer
    {

        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool IsItYoungDriver { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
