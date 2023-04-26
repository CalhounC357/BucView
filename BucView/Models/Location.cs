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
        [Range(-180, 180)]
        public decimal Longitude { get; set; }
        [Range(-90, 90)]
        public decimal Latitude { get; set; }
        public ICollection<LocationImage> Images { get; set; } = new List<LocationImage>();
        public ICollection<LocationType> Types { get; set; } = new List<LocationType>();
    }
}
