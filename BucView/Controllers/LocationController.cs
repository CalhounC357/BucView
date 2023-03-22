using BucView.Infrastructure;
using BucView.Models;
using Microsoft.AspNetCore.Mvc;

namespace BucView.Controllers
{
    public class LocationController : Controller
    {
        private readonly ITourRepository repo;
        public LocationController(ITourRepository _repo)
        {
            repo = _repo;
        }
        public async Task<IActionResult> Index(int id)
        {
            Location? loc = await repo.GetLocation(id);
            return View(loc);
        }
    }
}
