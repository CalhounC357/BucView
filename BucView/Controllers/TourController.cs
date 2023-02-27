using BucView.Infrastructure;
using BucView.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

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
    }
}
