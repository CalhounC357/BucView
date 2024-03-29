﻿using BucParking.Models;

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

        public ParkingLot? GetLotFromName(string name)
        {
            return parkingLots.Where(lot => lot.LotNum == name).FirstOrDefault();
        }

        public ParkingSpot? GetSpotFromId(int id)
        {
            return parkingSpots.Where(spot => spot.Id == id).FirstOrDefault();
        }
    }
}
