using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data
{
    public class TravelContext : DbContext
    {
        public TravelContext()
        {
        }
        public TravelContext(DbContextOptions<TravelContext> options)
                : base(options)
        {
        }
        public DbSet<TravelPackage> TravelPackages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=experis-travels;Integrated Security=True");
        }
    }
}
