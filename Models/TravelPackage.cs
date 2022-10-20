using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace webapp_travel_agency.Models
{
    public class TravelPackage
    {
        public TravelPackage()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CoverImage { get; set; }
        public string Description { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        [Precision(8, 2)]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public int? TransportId { get; set; }
        public Transport? Transport { get; set; }

        public int? DestinationId { get; set; }
        public Destination? Destination { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }


        public List<Tag>? Tags { get; set; }

    }
}
