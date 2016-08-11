using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            //make a movie object
            var movie = new Movie() { Name = "Shrek!" };

            //make a customer object
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            //pass both to the view model prop
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //movie can be passed as parameter to the view or using the ViewData, this is not a good approach
            //ViewData["Movie"] = movie;

            //return the view, and change the view html to using the view model
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if(!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }

        //    if(string.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        //attribute for custom route and setup constraints for parameter
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {


            return Content(year + "/" + month);
        }

        public ActionResult Index()
        {
            var movies = _context.Movie.Include(g => g.Genre).ToList();

            var viewModel = new MoviesViewModel
            {
                MoviesList = movies
            };
              
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movie.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);

            var movieViewModel = new MoviesViewModel
            {
                Movie = movie
            };

            return View(movieViewModel);
        }
        





        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Name = "Shrek" },
                new Movie { Name = "Terminator" }
            };
        }
    }
}