using BikeRental.API.Data;
using BikeRental.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            var result = _context.Bikes.Find(bikeId);
            result.Status = result == null ? null : _context.Statuses.Find(result?.StatusId);
            result.Type = result == null ? null : _context.Types.Find(result?.TypeId);
            return result;
        }

        public IEnumerable<Bike> GetBikes()
        {
            return _context.Bikes
                .Include(x => x.Status)
                .Include(y => y.Type)
                .ToList();
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

        public bool BikeExist(Guid bikeId)
        {
            return _context.Bikes.Any(x => x.Id == bikeId);
        }
    }
}
