using BucView.Infrastructure;
using BucView.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.Data.Sqlite;
using System.Dynamic;

namespace BucView.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourRepository repo;
        public TourController(ITourRepository _repo)
        {
            repo = _repo;
        }
        public async Task<IActionResult> Index(int id)
        {
            /* Passes the data needed for _Layout Food Dropdown, It is needed in every View so it doesn't crash. */
            dynamic myModel = new ExpandoObject();
            ICollection<Location> locationsOnCampus = await repo.ReadLocationByTags(Models.Type.Food, Models.Type.OnCampus);
            ICollection<Location> locationsOffCampus = await repo.ReadLocationByTags(Models.Type.Food, Models.Type.OffCampus);
            myModel.LocationsOne = locationsOnCampus;
            myModel.LocationsTwo = locationsOffCampus;
            ViewData["FoodData"] = myModel;
            /* Code Chunk ends */

            Tour? tour = await repo.GetTour(id);
            return View(tour);
        }

        public async Task<IActionResult> Location(int tourId, int rank)
        {
            /* Passes the data needed for _Layout Food Dropdown, It is needed in every View so it doesn't crash. */
            dynamic myModel = new ExpandoObject();
            ICollection<Location> locationsOnCampus = await repo.ReadLocationByTags(Models.Type.Food, Models.Type.OnCampus);
            ICollection<Location> locationsOffCampus = await repo.ReadLocationByTags(Models.Type.Food, Models.Type.OffCampus);
            myModel.LocationsOne = locationsOnCampus;
            myModel.LocationsTwo = locationsOffCampus;
            ViewData["FoodData"] = myModel;
            /* Code Chunk ends */

            TourLocation? tourLocation = await repo.GetTourLocation(tourId, rank);
            // Pass the location count to the view so we can know if it's the final location in the tour.
            int count = (await repo.GetTourLocations(tourId)).Count;
            ViewData["LocationCount"] = count;

            return View(tourLocation);
        }
        
        public async Task<IActionResult> NextLocation(int tourId, int rank)
        {

            /* In order to stop the page from crashing at an error when it reaches the end i just had 
             * it get count of ranks from database where tourId matches current one and then reset the rank number to 0 when it went over.
             * 
             * TO-DO:  may want a different option in future for when user reach end of tour locations
             */
            int count = (await repo.GetTourLocations(tourId)).Count;

            if (rank <= count)
            {
                return RedirectToAction("Location", new { tourId, rank });
            }
            
            return RedirectToAction("Index", "Tour", new {id=tourId});
            
        }

        public async Task<IActionResult> NextTour(int id)
        {
            int count = (await repo.GetListOfTours()).Count;

            if (id <= count)
            {
                return RedirectToAction("Index", new { id });
            }

            return RedirectToAction("Index", "Tour", new { id = 1 });
        }
    }
}
