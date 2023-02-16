using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucView.Models
{
    /*
     * Represents an interest point near a Location on a Tour (TourLocation)
     */
    public class TourLocationInterestPoint
    {
        public int Id { get; set; }
        public int TourLocationId { get; set; }
        public TourLocation? TourLocation { get; set; }
        public int InterestPointId { get; set; }
        public Location? InterestPoint { get; set; }
        // Not too necessary but if we want to have our interest points ranked on a page
        public int Rank { get; set; }
    }
}
