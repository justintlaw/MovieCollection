using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMovieAppRepository _repository;
        private MovieAppDbContext _context;

        public HomeController(ILogger<HomeController> logger, IMovieAppRepository repository, MovieAppDbContext context)
        {
            _logger = logger;
            _repository = repository;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListMovies()
        {
            // return the list of movies
            return View(_repository.Movies);
        }

        [HttpGet]
        public IActionResult EnterMovies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovies(Movie response)
        {
            // add a movie to the list
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Movie successfully added to the list.";
                _context.Add(response);
                _context.SaveChanges();
            }
            else
            {
                ViewBag.Message = "One or more inputs was invalid. The movie was not added to the list.";
            }

            return View("Confirmation");
        }

        [HttpGet]
        public IActionResult EditMovie(int MovieId)
        {
            return View(_repository.Movies
                .Where(m => m.MovieId == MovieId)
                .FirstOrDefault());
        }

        [HttpPost]
        public IActionResult EditMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Update(response);
                _context.SaveChanges();

                ViewBag.Message = "Changes successfully made.";
            }
            else
            {
                ViewBag.Message = "One or more inputs was invalid. The changes were not saved.";
            }

            return View("Confirmation");
        }

        [HttpPost]
        public IActionResult DeleteMovie(int MovieId)
        {
            _context.Remove(_repository.Movies
                .Where(m => m.MovieId == MovieId)
                .FirstOrDefault());
            _context.SaveChanges();
            ViewBag.Message = "Movie removed from the list.";

            return View("Confirmation");
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
