namespace BucView.Models
{
    /*
     * Represents a many-to-many relationship 
     * Allows a Location to be defined as several types of Locations
     */
    public class LocationType
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public Type Type { get; set; }
    }
    public enum Type
    {
        Food,
        OnCampus,
        OffCampus,
        Amenity,
        Recreation,
        Housing,
        Administration,
        Hall,
        Monument
    }
}
