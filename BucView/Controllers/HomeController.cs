using BucView.Infrastructure;
using BucView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;

namespace BucView.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ITourRepository repo;

        public HomeController(ITourRepository _repo)
        {
            repo = _repo;
        }
        
        public async Task<IActionResult> Index()
        {
            ICollection < Tour > tours = await repo.ReadTours();

            /* Passes the data needed for _Layout Food Dropdown, It is needed in every View so it doesn't crash. */
            dynamic myModel = new ExpandoObject();
            ICollection<Location> locationsOnCampus = await repo.ReadLocationByTags(Models.Type.Food, Models.Type.OnCampus);
            ICollection<Location> locationsOffCampus = await repo.ReadLocationByTags(Models.Type.Food, Models.Type.OffCampus);
            myModel.LocationsOne = locationsOnCampus;
            myModel.LocationsTwo = locationsOffCampus;
            ViewData["FoodData"] = myModel;
            /* Code Chunk ends */

            return View(tours);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}