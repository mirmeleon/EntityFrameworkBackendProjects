namespace BusTicketsystem.Model
{
    using System;
    public class Trip
    {
        
        public int Id { get; set; }

        public DateTime? DepartureTime { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public Status Status { get; set; }

        public virtual BusStation OriginBusStation{ get; set; } 

        public virtual BusStation DestinationBusStation { get; set; } 

        public virtual BusCompany BusCompany { get; set; }
    }

    public enum Status
    {
        Departed, Arrived, Delayed, Cancelled
    }
}
