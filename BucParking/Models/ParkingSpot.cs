namespace BucParking.Models
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public int ParkingLotId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ParkingType Type { get; set; }
    }
}
