namespace BucView.Models
{
    /**
     * Represents a series of ordered locations
     */
    public class Tour
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        // URL to a thumbnail or some kind of image that represents the tour
        // Image stored in the project
        public string? ImageUrl { get; set; }
        // Ranking of the tour; i.e. placement in the list of tours
        // Lower value means higher on the list; 0 would be top of the list
        // This is meant to be arbitrary/not directly ordered, so you could enter 10000 if you really want it at the bottom
        // Or enter the same rank for different tours if you don't care the order
        public int Rank { get; set; }
        // Time in minutes estimating how long the tour takes
        public int EstimatedTime { get; set; }
        public ICollection<TourLocation> Locations { get; set; } = new List<TourLocation>();
    }
}
