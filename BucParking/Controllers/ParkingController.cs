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



        [HttpGet("nearby")]
        public ActionResult<string> Nearby(int lat, int lon, string filter)
        {
            //Test to check if data is retrieved.
            //var count = parkingData.parkingSpots.Count;
            
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

            var lots = new object[] { lotjson, lotjson2 };

            string jsonData = JsonConvert.SerializeObject(lots);

            return jsonData;
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
