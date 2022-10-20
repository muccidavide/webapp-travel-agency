using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace webapp_travel_agency.Models
{
    public class TravelPackage
    {
        public TravelPackage()
        {
        }

        public TravelPackage(string name, string description, string destination, DateTime departureDate, DateTime returnDate, decimal price, bool isAvailable)
        {
            Name = name;
            Description = description;
            Destination = destination;
            DepartureDate = departureDate;
            ReturnDate = returnDate;
            Price = price;
            IsAvailable = isAvailable;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        [Precision(8, 2)]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
            
    }
}
