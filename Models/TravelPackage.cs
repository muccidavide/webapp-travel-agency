using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;




/// <summary>
/// TravelPackage rappresenta il modello principale al quale sono collegate tutte le relazioni:
/// - Category(1 a molti): rappresenta la categoria del viaggio(coppia, famiglia, etc)
/// - Transport(1 a molti): rappresenta il mezzo di trasporto
/// - Destination(1 a molti): indica  la destinazione del viaggio
/// - Tags(molti a molti): utilizzati per taggare i vari pacchetti
/// 
/// NON E' presente alcuna validazione a livello di db ad eccenzione di un controllo sull'unicità del nome delle categorie, traporti, destinazioni;
/// </summary>
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
