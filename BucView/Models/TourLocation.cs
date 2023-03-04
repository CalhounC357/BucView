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
        // This is probably a google maps API link without the api key
        // Which would mean:
        // This url has {key} where the API key should be
        // The api key is in a configuration file not in the git repo
        // So that we don't expose it to the world
        // The code takes the api key and replaces {key} with it whenever called
        // If there's some other way to do this then ignore this. Like having an unchanging image would make this much easier
        public string? EmbeddedMapUrl { get; set; }
        public ICollection<TourLocationInterestPoint> InterestPoints { get; set; } = new List<TourLocationInterestPoint>();
    }
}
