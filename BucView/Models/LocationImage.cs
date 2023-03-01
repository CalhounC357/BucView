using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucView.Models
{
    /*
     * Represents an image associated to a Location
     */
    public class LocationImage
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }
        // URL to image stored in the project
        public string? ImageUrl { get; set; }
        // This is a ranking starting at 0 that must be ordered and unique
        // i.e. no two TourLocations in the same Tour have the same rank, or have a gap between numbers
        public int Rank { get; set; }
    }
}
