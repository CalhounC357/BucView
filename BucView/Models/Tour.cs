using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucView.Models
{
    /**
     * Represents a series of ordered locations
     */
    public class Tour
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        [Required]
        public int Rank { get; set; }
        [NotMapped]
        public ICollection<TourLocation> Locations { get; set; } = new List<TourLocation>();
    }
}
