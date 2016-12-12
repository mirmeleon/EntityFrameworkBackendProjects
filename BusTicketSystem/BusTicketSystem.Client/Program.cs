namespace BusTicketSystem.Client
{
    using System;
    using BusTicketSystem.Data;

    class Program
    {
        static void Main()
        {
            UnitOfWork work = new UnitOfWork();
            
            string input = Console.ReadLine();
            string[] tokens = input.Split(' ');
            ExecuteCommand(tokens, work);
           
        }

        private static void ExecuteCommand(string[] tokens, UnitOfWork work)
        {
  
            int id = 0;

            switch (tokens[0])
            {
                case "print-info":
                   
                    id = int.Parse(tokens[1]);
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }

           
            var busStation = work.BusStations.Find(s => s.Id == id); 

            foreach (var st in busStation)
            {
                Console.WriteLine("Departures:");
                Console.WriteLine($"To {st.Name} |");
                foreach (var s in st.OriginBusStationTrips)
                {
                    Console.WriteLine($"Depart at: {s.DepartureTime} | Status: {s.Status}");
                }
            }
        
        }
    }
}
