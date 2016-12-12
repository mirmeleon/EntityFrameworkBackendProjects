namespace BusTicketsystem.Model
{
    using System.Collections.Generic;
    public class BusCompany
    {
        public BusCompany()
        {
            this.Reviews = new HashSet<Review>();
        }
        
        public int Id { get; set; }

        public string Name { get;set; }

        public string Nationality { get; set; }

        public decimal Rating { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
