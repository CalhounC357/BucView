using BucParking.Models;

namespace BucParking.Service
{
    public interface IParkingData
    {
        List<ParkingSpot> parkingSpots  {get; }

        List<ParkingLot> parkingLots { get; }

    }
}
