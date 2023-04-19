using BucParking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace BucParking.Controllers
{
    [Route("api/parking")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        [HttpGet("nearby")]
        public ActionResult<ParkingSpot> Nearby(int lat, int lon, string filter)
        {
            ParkingSpot spot = new ParkingSpot();
            spot.Longitude = lon;
            spot.Latitude = lat;
            spot.Id = 2;
            spot.ParkingLotId = 3;
            return spot;
        }

        public ActionResult<ParkingSpot> Nearby()
        {
            ParkingSpot spot = new ParkingSpot();
            spot.Longitude = 1;
            spot.Latitude = 1;
            spot.Id = 2;
            spot.ParkingLotId = 3;
            return spot;
        }
    }
}
