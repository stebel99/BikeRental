using BikeRental.API.Models;
using System;
using System.Collections.Generic;

namespace BikeRental.API.Repository
{
    public interface IBikeRepository : IDisposable
    {
        IEnumerable<Bike> GetBikes();
        Bike GetBikeById(Guid bikeId);
        void InsertBike(Bike bike);
        void DeleteBike(Guid bikeId);
        void UpdateBike(Bike bike);
        void Save();
        bool BikeExist(Guid bikeId);
    }
}
