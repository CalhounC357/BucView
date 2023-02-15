using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucView.Models
{
    /*
     * Represents a destination
     */
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        [Required]
        public string? EmbeddedMapUrl { get; set; }
        [NotMapped]
        public ICollection<LocationImage> Images { get; set; } = new List<LocationImage>();
    }
}
