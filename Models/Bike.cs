using System;

namespace BikeRental.API.Models
{
    public class Bike
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int TypeId { get; set; }
        public Type Type { get; set; }

        public int StatusId{ get; set; }
        public Status Status { get; set; }
    }
}