using BikeRental.API.Data;
using BikeRental.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRental.API.Repository
{
    public class BikeRepository : IBikeRepository, IDisposable
    {
        private readonly DataContext _context;

        public BikeRepository(DataContext context)
        {
            _context = context;
        }

        public void DeleteBike(Guid bikeId)
        {
            Bike bike = _context.Bikes.Find(bikeId);
            _context.Bikes.Remove(bike);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Bike GetBikeById(Guid bikeId)
        {
            return _context.Bikes.Find(bikeId);
        }

        public IEnumerable<Bike> GetBikes()
        {
            return _context.Bikes.ToList();
        }

        public void InsertBike(Bike bike)
        {
            _context.Bikes.Add(bike);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateBike(Bike bike)
        {
            _context.Entry(bike).State = EntityState.Modified;
        }
    }
}
