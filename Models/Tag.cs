using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TravelPackage>? TravelPackages { get; set; }
        public Tag()
        {

        }
    }
}