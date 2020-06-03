using Microsoft.EntityFrameworkCore;

namespace BikeRental.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    }
}