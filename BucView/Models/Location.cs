using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucView.Models
{
    /*
     * Represents a destination
     */
    public class Location
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Range(-180, 180)]
        public decimal Longitude { get; set; }
        [Range(-90, 90)]
        public decimal Latitude { get; set; }
        // This is probably a google maps API link without the api key
        // Which would mean:
        // This url has {key} where the API key should be
        // The api key is in a configuration file not in the git repo
        // So that we don't expose it to the world
        // The code takes the api key and replaces {key} with it whenever called
        // If there's some other way to do this then ignore this. Like having an unchanging image would make this much easier
        public string? EmbeddedMapUrl { get; set; }
        public ICollection<LocationImage> Images { get; set; } = new List<LocationImage>();
    }
}
