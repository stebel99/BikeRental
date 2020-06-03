using System.Collections.Generic;

namespace BikeRental.API.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Bike> Bikes { get; set; }
    }
}