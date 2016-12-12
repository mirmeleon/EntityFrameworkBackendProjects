namespace BusTicketsystem.Model
{
    using System;
    using System.Collections.Generic;
  
    public class Customer
    {
        public Customer()
        {
            this.ReviewsByCustomer = new HashSet<Review>();
        }


        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public virtual Town HomeTown { get; set; }

        
        public virtual BankAccount BankAccount { get; set; }

        public virtual ICollection<Review> ReviewsByCustomer { get; set; }
    }

    public enum Gender
    {
        male, female, notSpecified
    }
}
