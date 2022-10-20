using Microsoft.EntityFrameworkCore;

namespace webapp_travel_agency.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        public Category()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<TravelPackage> TravelPackages { get; set; }

    }
}