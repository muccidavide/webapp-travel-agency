namespace webapp_travel_agency.Models
{
    public class Destination
    {
        public Destination()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public List<TravelPackage> TravelPackages { get; set; }
    }
}