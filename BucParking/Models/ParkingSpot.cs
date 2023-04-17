using System.Reflection.Metadata.Ecma335;

namespace BucParking.Models
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public int ParkingLotId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ParkingType Type { get; set; }

        public static ParkingSpot SpotsFromCsv(string csvLine)
        {
            String[] values = csvLine.Split(',');
            ParkingSpot parkingSpotsData = new ParkingSpot();
            parkingSpotsData.Id = ;
            parkingSpotsData.ParkingLotId = int.Parse(values[5]);
            parkingSpotsData.Latitude = double.Parse(values[1]);
            parkingSpotsData.Longitude = double.Parse(values[0]);
            parkingSpotsData.Type = ;

            return parkingSpotsData;
        }
    }
}
