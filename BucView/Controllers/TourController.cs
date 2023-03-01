using BucView.Infrastructure;
using BucView.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BucView.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourRepository repo;
        private readonly IWebHostEnvironment _HostEnvironment;


        //Variables needed for next and back button functions
        public List<string> listOfViews = new List<string>();
        public int viewsIteraterNum = 0;

        public TourController(ITourRepository _repo, IWebHostEnvironment HostEnvironment)
        {
            repo = _repo;
            _HostEnvironment = HostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<Tour> tours = await repo.ReadTours();
            return View(tours);
        }

        //goes into the directory using the pathing of the hosting environment, and pulls the views available for Tour
        public void GetListOfViews()
        {
            string contentRootPath = _HostEnvironment.ContentRootPath;

            //retrieves file, remove all pathing and file extension to make it valid.
            String[] viewFiles = Directory.GetFiles(contentRootPath + "/Views/Home/", "*.cshtml");
            foreach (string file in viewFiles)
            {
                string viewName = Path.GetFileNameWithoutExtension(file);
                listOfViews.Add(viewName);
            }

            //testing purpose to make sure it was pulling the correct files into the list.
           /* foreach (string file in listOfViews)
            {
                Console.WriteLine(file);
            }
           */
        }

        // The method that defines what happens when you click "Back" button on Webpage.
        public IActionResult BackButton()
        {
            //If the list of views available to pull from is empty it will run the method to get it from directory.
            if (listOfViews.Count == 0)
            {
                GetListOfViews();
            }

            //moves backwards in list and makes sure the number doesn't go into to the negative by resetting the count to last view in list
            viewsIteraterNum--;
            if (viewsIteraterNum <= 0)
            {
                viewsIteraterNum = listOfViews.Count - 1;
            }
            //Redirect view to next view in list.
            return Redirect(listOfViews[viewsIteraterNum]);
        }


        // The method that defines what happens when you click "Next" button on Webpage.
        public IActionResult NextButton()
        {
            //If the list of views available to pull from is empty it will run the method to get it from directory.
            if (listOfViews.Count == 0)
            {
                GetListOfViews();
            }
            //moves fowards in list and makes sure the number doesn't go into to the negative by resetting the count to first view in list
            viewsIteraterNum++;
            if (viewsIteraterNum >= listOfViews.Count)
            {
                viewsIteraterNum = 0;
            }
            //Redirect view to next view in list.
            return Redirect(listOfViews[viewsIteraterNum]);
        }
    }
}
