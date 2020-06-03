using BikeRental.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Type> Types { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Status>().HasData(
                new Status[]
                {
                    new Status { Id = 1, Name = "Available"},
                    new Status { Id = 2, Name = "Rented" }
                });

            builder.Entity<Type>().HasData(
                new Type[]
                {
                    new Type {Id = 1, Name = "Road" },
                    new Type {Id = 2, Name = "Mountain" },
                    new Type {Id = 3, Name = "Common" },
                });
        }
    }
}