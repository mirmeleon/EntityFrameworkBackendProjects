namespace BusTicketSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using BusTicketsystem.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<BusTicketSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "BusTicketSystemContext";
        }

        protected override void Seed(BusTicketSystemContext context)
        {
           
            context.BankAccounts.AddOrUpdate(ba=>ba.Id,
              new BankAccount()
              {
                  AccountNumber = "Sa24343sds", Balance = 2010.12m, 
                  Customer = new Customer() { FirstName = "Stoian", LastName = "Ivanov", Gender = Gender.male, DateOfBirth = new DateTime(1983,12,01)}
              });

            context.BusCompanies.AddOrUpdate(bc=>bc.Id,
               new BusCompany()
               {
                   Name = "SuperFast Travels",
                   Nationality = "Bulgarian",
                   Rating = 10.2m
               } );
            context.BusStations.AddOrUpdate(bs=>bs.Id,
                new BusStation()
                {
                    Name = "Central Stattion",
                    Town = new Town()
                    {
                        Name = "Sofia",
                        Country = "Bulgaria"
                    },
                    DepartureBusStationTrips = new HashSet<Trip>() { new Trip()
                    {
                        DepartureTime = DateTime.Now,
                         ArrivalTime = DateTime.Today,
                         Status = Status.Delayed,
                         OriginBusStation = new BusStation() {Name = "Station Iskur", Town = new Town()
                         {
                             Name = "Iskur", Country = "Bulgaria"
                         } }

                    } }
                });

            context.Reviews.AddOrUpdate(r=>r.Id,
                new Review()
                {
                    Content = "Very good company! I had amazing travel!",
                    Grade = 10.00m
                   
                });

            context.Tickets.AddOrUpdate(t=>t.Id,
                new Ticket()
                {
                    Price = 12.05m,
                    Seat = "15A",
                    Trip = new Trip()
                    {
                        BusCompany = new BusCompany() {Name = "Samanta AD", Nationality = "USA", Rating = 0.1m}
                    },
                    
                });

            context.SaveChanges();
        }
    }
}
