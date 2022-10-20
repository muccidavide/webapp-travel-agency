using Microsoft.EntityFrameworkCore;

namespace webapp_travel_agency.Models
{
    /// relation 1 to many with TravelPackage
    [Index(nameof(Name), IsUnique = true)]
    public class Transport
    {
        public Transport()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<TravelPackage> TravelPackages { get; set; }

    }
}
