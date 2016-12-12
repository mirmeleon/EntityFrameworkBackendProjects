namespace BusTicketSystem.Data
{

    using BusTicketSystem.Data.Contracts;
    using BusTicketsystem.Model;
    using BusTicketSystem.Data.Repositories;
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BusTicketSystemContext context;
        private IRepository<BankAccount> bankAccounts;
        private IRepository<BusCompany> busCompanies;
        private IRepository<BusStation> busStations;
        private IRepository<Customer> customers;
        private IRepository<Review> reviews;
        private IRepository<Ticket> tickets;
        private IRepository<Town> towns;
        private IRepository<Trip> trips;

        public UnitOfWork()
        {
            this.context = new BusTicketSystemContext();
        }

        public IRepository<BankAccount> BankAccounts
        {
          get { return bankAccounts ?? (this.bankAccounts = new Repository<BankAccount>(this.context.BankAccounts));}
        }


        public IRepository<BusCompany> BusCompanies
        {
            get {return busCompanies ?? (this.busCompanies = new Repository<BusCompany>(this.context.BusCompanies));}
        }

        public IRepository<BusStation> BusStations
        {
             get
             {
                 return busStations ?? (this.busStations = new Repository<BusStation>(this.context.BusStations));
             }
        }

        public IRepository<Customer> Customers
        {
            get { return customers ?? (this.customers = new Repository<Customer>(this.context.Customers)); }
        }

        public IRepository<Review> Reviews
        {
            get
            {
                return reviews ?? (this.reviews = new Repository<Review>(this.context.Reviews));
            }
        }

        public IRepository<Ticket> Tickets
        {
            get
            {
                return tickets ?? (this.tickets = new Repository<Ticket>(this.context.Tickets));
            }
        }

        public IRepository<Town> Towns
        {
            get
            {
                return towns ?? (this.towns = new Repository<Town>(this.context.Towns));
            }
        }

        public IRepository<Trip> Trips
        {
            get
            {
                return trips ?? (this.trips = new Repository<Trip>(this.context.Trips));
            }
        }
        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
