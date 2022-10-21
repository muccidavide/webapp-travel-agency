using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Message
    {
        public Message()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public string Sender { get; set; }

        public TravelPackage? TravelPackage { get; set; }
        public int TravelPackageId { get; set; }
    }
}
