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
        public int Rank { get; set; }
        public ICollection<TourLocationInterestPoint> InterestPoints { get; set; } = new List<TourLocationInterestPoint>();
    }
}
