using BucView.Infrastructure;
using BucView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BucView.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITourRepository repo;
        public HomeController(ITourRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IActionResult> IndexAsync()
        {

            ICollection<Tour> tours = await repo.ReadTours();

            /*var tours = new List<Tour>()
            {
                new Tour()
                {
                    Name = "CBAT"
                },

                new Tour() 
                {
                    Name = "General"
                },

                new Tour()
                {
                    Name = "Nursing"
                }
            };*/

            return View(tours);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}