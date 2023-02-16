using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucView.Models
{
    /*
     * Represents a destination
     */
    public class Location
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string? EmbeddedMapUrl { get; set; }
        public ICollection<LocationImage> Images { get; set; } = new List<LocationImage>();
    }
}
