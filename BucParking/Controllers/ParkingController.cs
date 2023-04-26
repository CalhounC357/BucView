using BucParking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using System.Device.Location;
using BucParking.Service;



namespace BucParking.Controllers
{
    [Route("api/parking")]
    [ApiController]
    public class ParkingController : ControllerBase
    {

        private readonly IParkingData parkingData;

        public ParkingController (IParkingData _parkingData)
        {
           parkingData = _parkingData;
            
        }

        private class SpotDataDto
        {
            public int SpotId { get; set; }
            public double Distance { get; set; }
        }

        [HttpGet("nearby")]
        public ActionResult<string> Nearby(decimal lat, decimal lon, string filter)
        {
            //Test to check if data is retrieved.
            var count = parkingData.parkingSpots.Count;
            List<ParkingLot> lots = new List<ParkingLot>();
            // pairs containing the lot name and the distance from the spot to the given location
            Dictionary<string, SpotDataDto> lotsAndDistance = new Dictionary<string, SpotDataDto>();
            foreach (ParkingSpot spot in parkingData.parkingSpots)
            {
                // add undesig spots and appropriate enter filter in url
                if (spot.Type.ToString().ToLower() != filter.ToLower() && 
                    spot.Type != ParkingType.Undesignated) {
                    continue;
                }

                decimal spotLat = spot.Latitude;
                decimal spotLon = spot.Longitude;
                double distance = Math.Sqrt(Math.Pow((double)(spotLat - lat), 2) + Math.Pow((double)(spotLon - lon), 2));

                SpotDataDto? existingClosestSpot = lotsAndDistance.GetValueOrDefault(spot.ParkingLotId);
                var existingDist = existingClosestSpot?.Distance;
                if (existingDist == 0 || existingDist == null) existingDist = Double.MaxValue;

                if (distance < existingDist)
                {
                    lotsAndDistance.Remove(spot.ParkingLotId);
                    lotsAndDistance.Add(spot.ParkingLotId, new SpotDataDto { SpotId = spot.Id, Distance = distance });
                }
            }
            var spotsSortedByDistance = from entry in lotsAndDistance orderby entry.Value.Distance ascending select entry;
            // just assuming there's 3 entries here
            var lotsData = new object[3];
            for (int i = 0; i < 3; i++)
            {
                string bestLotName = spotsSortedByDistance.ElementAt(i).Key;
                ParkingLot? bestLot = parkingData.GetLotFromName(bestLotName);
                ParkingSpot? bestSpot = parkingData.GetSpotFromId(spotsSortedByDistance.ElementAt(i).Value.SpotId);
                lotsData[i] = new
                {
                    lot_name = bestLotName,
                    available_spots = bestLot?.ParkingSpots.Count,
                    closest_lat = bestSpot?.Latitude,
                    closest_long = bestSpot?.Longitude,
                    distance = spotsSortedByDistance.ElementAt(i).Value,
                    map_link = 0
                };
            }

            string jsonData = JsonConvert.SerializeObject(lotsData);

            return jsonData;

            /*
            var lotjson = new
            {
                lot_name = "asdf",
                available_spots = 200,
                closest_lat = 37.5,
                closest_long = -122.4,
                distance = 0.65,
                map_link = "https://www.google.com/maps/embed/v1/place?q=place_id:ChIJZ8b99Yp-j4ARDrTtb1dK0vg"
            };

            var lotjson2 = new
            {
                lot_name = "asdf2",
                available_spots = 200,
                closest_lat = 37.5,
                closest_long = -122.4,
                distance = 0.65,
                map_link = "https://www.google.com/maps/embed/v1/place?q=place_id:ChIJZ8b99Yp-j4ARDrTtb1dK0vg"
            };

            var lotstest = new object[] { lotjson, lotjson2 };

            string jsonData = JsonConvert.SerializeObject(lotstest);

            return jsonData;*/
        }

        public ActionResult<ParkingSpot> Nearby()
        { 
            ParkingSpot spot = new ParkingSpot();
            spot.Longitude = 1;
            spot.Latitude = 1;
            
            return spot;

        }

        public string GetUserLocation(double latitude, double longitude)
        {
            // Create a GeoCoordinate object for the user's location
            GeoCoordinate userLocation = new GeoCoordinate(latitude, longitude);
            return latitude + ", " + longitude; // Can't figure out a better return method than this one.
        }

}
}
