namespace BucParking.Models
{
    public class ParkingLot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ShapeLength { get; set; }
        public double ShapeArea { get; set; }

        public List<ParkingSpot> ParkingSpots { get; set; } = new List<ParkingSpot>();
    }
}
