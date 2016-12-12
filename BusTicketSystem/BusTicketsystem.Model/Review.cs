namespace BusTicketsystem.Model
{
    using System;
    using System.Collections.Generic;
    public class Review
    {
        public Review()
        {
            this.BusCompaniesReviews = new HashSet<BusCompany>();
        }
        public int Id { get; set; }

        public string Content { get; set; }

        public decimal Grade { get; set; }

        public virtual BusStation BusStation { get; set; }

        public virtual Customer Customer { get; set; }

        public  DateTime? PublishedIn { get; set; }

        public virtual ICollection<BusCompany> BusCompaniesReviews { get; set; }
    }
}
