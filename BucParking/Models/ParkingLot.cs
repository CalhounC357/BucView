namespace BucParking.Models
{
    public class ParkingLot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ShapeLength { get; set; }
        public double ShapeArea { get; set; }

        public List<ParkingSpot> ParkingSpots { get; set; } = new List<ParkingSpot>();

        public static ParkingLot LotFromCsv(string csvLine)
        { 
            List<ParkingSpot> parkingSpotData = File.ReadAllLines(@"wwwroot/data/Parking_Spots.csv")
			.Skip(1)
			.Select(v => ParkingSpot.SpotsFromCsv(v))
			.ToList();

			String[] values = csvLine.Split(',');
            ParkingLot parkingLotData = new ParkingLot();
            parkingLotData.Id = int.Parse(values[0]);
            parkingLotData.Name = values[3];
            parkingLotData.ShapeLength = double.Parse(values[4]);
            parkingLotData.ShapeArea = double.Parse(values[5]);
            parkingLotData.ParkingSpots = (List<ParkingSpot>)parkingSpotData.Where(v => v.ParkingLotId == parkingLotData.Name);
			return parkingLotData;

        }
    }
}
