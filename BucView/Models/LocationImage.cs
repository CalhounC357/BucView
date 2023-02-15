using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucView.Models
{
    /*
     * Represents an image associated to a Location
     */
    public class LocationImage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int LocationId { get; set; }
        [NotMapped]
        public Location? Location { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        [Required]
        public int Rank { get; set; }
    }
}
