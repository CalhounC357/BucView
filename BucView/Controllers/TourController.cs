using BucView.Infrastructure;
using BucView.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult CBAT()
        {
            return View();
        }

        public IActionResult General() 
        {
            return View();
        }

        public IActionResult Nursing() 
        {
            return View();        
        }
    }
}
