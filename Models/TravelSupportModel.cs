using System.ComponentModel;

namespace webapp_travel_agency.Models
{
    public class TravelSupportModel
    {
        public TravelSupportModel()
        {
            TravelPackage = new TravelPackage();
            Destinations = new List<Destination>();
            Transports = new List<Transport>();
            Categories = new List<Category>();
            Tags = new List<Tag>();
        }

        public TravelPackage TravelPackage { get; set; }
        public List<Destination> Destinations  { get; set; }
        public List<Transport> Transports { get; set; }
        public List<Category> Categories { get; set; }
        public List<Tag> Tags { get; set; }
        public List<int> SelectedTags { get; set; }
    }
}
