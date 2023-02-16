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
        public string? ImageUrl { get; set; }
        public int Rank { get; set; }
    }
}
