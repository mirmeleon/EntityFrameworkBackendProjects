namespace BusTicketSystem.Data
{
    using System.Data.Entity;
    using BusTicketsystem.Model;

    public class BusTicketSystemContext : DbContext
    {
        
        public BusTicketSystemContext()
            : base("name=BusTicketSystemContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BusTicketSystemContext>());
        }

       
        public virtual IDbSet<BankAccount> BankAccounts { get; set; }
        public virtual IDbSet<BusCompany> BusCompanies { get; set; }
        public virtual IDbSet<BusStation> BusStations { get; set; }
        public virtual IDbSet<Customer> Customers { get; set; }
        public virtual IDbSet<Review> Reviews { get; set; }
        public virtual IDbSet<Ticket> Tickets { get; set; }
        public virtual IDbSet<Town> Towns { get; set; }
        public virtual IDbSet<Trip> Trips { get; set; }


    }

}