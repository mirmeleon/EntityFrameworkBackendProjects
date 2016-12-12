namespace BusTicketSystem.Data.Contracts
{
   using BusTicketsystem.Model;
    public interface IUnitOfWork
    {
        IRepository<BankAccount> BankAccounts { get; }
        IRepository<BusCompany> BusCompanies { get; }
        IRepository<BusStation> BusStations { get; }
        IRepository<Customer> Customers { get; }
        IRepository<Review> Reviews { get; }
        IRepository<Ticket> Tickets { get; }
        IRepository<Town> Towns { get; }
        IRepository<Trip> Trips { get; }

        void Save();

    }
}
