using System.Reflection.Metadata.Ecma335;

namespace BucParking.Models
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public string ParkingLotId { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public ParkingType Type { get; set; }

        public static ParkingSpot SpotsFromCsv(string csvLine)
        {
            String[] values = csvLine.Split(',');
            ParkingSpot parkingSpotsData = new ParkingSpot();
            parkingSpotsData.Id = int.Parse(values[3]);
            parkingSpotsData.ParkingLotId = values[5];
            parkingSpotsData.Latitude = decimal.Parse(values[1]);
            parkingSpotsData.Longitude = decimal.Parse(values[0]);
            parkingSpotsData.Type = Enum.Parse<ParkingType>(values[6], true);

            return parkingSpotsData;
        }
    }
}
