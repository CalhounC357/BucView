using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucView.Models
{
    /*
     * Represents an interest point near a Location on a Tour (TourLocation)
     */
    public class TourLocationInterestPoint
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TourLocationId { get; set; }
        [NotMapped]
        public TourLocation? TourLocation { get; set; }
        [Required]
        public int InterestPointId { get; set; }
        [NotMapped]
        public Location? InterestPoint { get; set; }
        [Required]
        public int Rank { get; set; }
    }
}
