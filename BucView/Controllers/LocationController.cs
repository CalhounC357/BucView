using BucView.Infrastructure;
using BucView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

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
            /* Passes the data needed for _Layout Food Dropdown, It is needed in every View so it doesn't crash. */
            dynamic myModel = new ExpandoObject();
            ICollection<LocationType> locationsOnCampus = await repo.ReadLocationByTags(Models.Type.Food, Models.Type.OnCampus);
            ICollection<LocationType> locationsOffCampus = await repo.ReadLocationByTags(Models.Type.Food, Models.Type.OffCampus);
            myModel.LocationsOne = locationsOnCampus;
            myModel.LocationsTwo = locationsOffCampus;
            ViewData["FoodData"] = myModel;
            /* Code Chunk ends */

            Location? loc = await repo.GetLocation(id);

            return View(loc);
        }
    }
}
