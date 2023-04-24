using BucParking.Models;

namespace BucParking.Service
{
    public class ParkingData : IParkingData
    {


            public List<ParkingSpot> parkingSpots => File.ReadAllLines(@"wwwroot/data/Parking_Spots.csv")
           .Skip(1)
           .Select(v => ParkingSpot.SpotsFromCsv(v))
           .ToList();

            public List<ParkingLot> parkingLots => File.ReadAllLines(@"wwwroot/data/Parking_Lots.csv")
                .Skip(1)
                .Select(v => ParkingLot.LotFromCsv(v))
                .ToList();
    }
}
