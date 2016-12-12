namespace BusTicketsystem.Model
{
    using System.Collections.Generic;
    public class Town
    {
        public Town()
        {
            this.BusStations = new HashSet<BusStation>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BusStation> BusStations { get; set; }

        public string Country { get; set; }
    }
}
