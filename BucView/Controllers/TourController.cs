using BucView.Infrastructure;
using BucView.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.Data.Sqlite;

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
            Tour? tour = await repo.GetTour(id);
            return View(tour);
        }

        public async Task<IActionResult> Location(int tourId, int rank)
        {
            TourLocation tourLocation = await repo.GetTourLocation(tourId, rank);
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

            if (rank <= count - 1)
            {
                return RedirectToAction("Location", new { tourId, rank });
            }
            rank = 1;

            return RedirectToAction("Location", new { tourId, rank });
        }
    }
}
