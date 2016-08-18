using System;
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

        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

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

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movie.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);

            var movieViewModel = new MoviesViewModel(movie);
            
            return View(movieViewModel);
        }
        
        public ActionResult New()
        {
            var genreList = _context.MovieGenres.ToList();

            var viewModel = new MoviesViewModel
            {
                MovieGenre = genreList
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesViewModel(movie)
                {
                    MovieGenre = _context.MovieGenres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.AddedToInventory = DateTime.Now;
                _context.Movie.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movie.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.MovieGenreId = movie.MovieGenreId;
                movieInDb.QtyInStock = movie.QtyInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.SingleOrDefault(m => m.Id == id);

            if(movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MoviesViewModel(movie)
            {
                MovieGenre = _context.MovieGenres.ToList()
            };

            return View("MovieForm", viewModel);
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