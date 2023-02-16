using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucView.Models
{
    /**
     * Represents a series of ordered locations
     */
    public class Tour
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int Rank { get; set; }
        public ICollection<TourLocation> Locations { get; set; } = new List<TourLocation>();
    }
}
