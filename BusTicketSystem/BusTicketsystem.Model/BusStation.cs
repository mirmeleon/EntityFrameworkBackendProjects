namespace BusTicketsystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BusStation
    {
        public BusStation()
        {
            this.OriginBusStationTrips = new HashSet<Trip>();
            this.DepartureBusStationTrips = new HashSet<Trip>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public Town Town { get; set; }

        
        [InverseProperty("OriginBusStation")]
        public virtual ICollection<Trip> OriginBusStationTrips { get; set; }

        [InverseProperty("DestinationBusStation")]
        public virtual ICollection<Trip> DepartureBusStationTrips { get; set; }
    }
}
