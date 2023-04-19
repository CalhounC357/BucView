namespace BucParking.Models
{
    public class ParkingLot
    {
        public int Id { get; set; }
        public string LotNum { get; set; }
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
            parkingLotData.LotNum = values[3];
            parkingLotData.ShapeLength = double.Parse(values[4]);
            parkingLotData.ShapeArea = double.Parse(values[5]);
            foreach (var parkingSpot in parkingSpotData)
            {
                if (String.Equals(parkingSpot.Id, parkingLotData.LotNum)){
                    parkingLotData.ParkingSpots.Add(parkingSpot);
                }
            }
			return parkingLotData;

        }
    }
}
