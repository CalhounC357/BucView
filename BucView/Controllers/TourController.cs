using BucView.Infrastructure;
using BucView.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BucView.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourRepository repo;
        public TourController(ITourRepository _repo)
        {
            repo = _repo;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<Tour> tours = await repo.ReadTours();
            return View(tours);
        }

        /*
         * This is a test method for troubleshooting the behavior of the location page image gallery with a mocked location
         * !! IT SHOULD NOT BE ACTIVE IN PRODUCTION !!
         */
        public async Task<IActionResult> Location()
        {
            var model = new TourLocation
            {
                Location = new Location
                {
                    Id = 1,
                    Name = "Culp Center",
                    Description = "an important place on campus",
                    Longitude = 0,
                    Latitude = 0,
                    Images = new List<LocationImage>()
                    {
                        new LocationImage()
                        {
                            Rank = 1,
                            ImageUrl = "images\\test\\culp_center_header-hero-lead.jpg"
                        },
                        new LocationImage()
                        {
                            Rank = 2,
                            ImageUrl = "images\\test\\culp1.jpg"
                        },
                        new LocationImage()
                        {
                            Rank = 3,
                            ImageUrl = "images\\test\\culpa.jpg"
                        },
                        new LocationImage()
                        {
                            Rank = 4,
                            ImageUrl = "images\\test\\culpcenter1.jpg"
                        }
                    }
                }
            };
            return View(model);
        }
    }
}
