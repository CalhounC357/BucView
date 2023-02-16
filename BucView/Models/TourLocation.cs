using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucView.Models
{
    /*
     * Weak entity for Locations within a Tour
     */
    public class TourLocation
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public Tour? Tour { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }
        // This is a ranking starting at 0 that must be ordered and unique
        // i.e. no two TourLocations in the same Tour have the same rank, or have a gap between numbers
        public int Rank { get; set; }
        public ICollection<TourLocationInterestPoint> InterestPoints { get; set; } = new List<TourLocationInterestPoint>();
    }
}
