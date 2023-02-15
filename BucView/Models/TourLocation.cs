using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucView.Models
{
    /*
     * Weak entity for Locations within a Tour
     */
    public class TourLocation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TourId { get; set; }
        [NotMapped]
        public Tour? Tour { get; set; }
        [Required]
        public int LocationId { get; set; }
        [NotMapped]
        public Location? Location { get; set; }
        [Required]
        public int Rank { get; set; }
        [NotMapped]
        public ICollection<TourLocationInterestPoint> InterestPoints { get; set; } = new List<TourLocationInterestPoint>();
    }
}
