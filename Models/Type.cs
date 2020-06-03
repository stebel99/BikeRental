using System.Collections.Generic;

namespace BikeRental.API.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Bike> Bikes { get; set; }
    }
}