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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListMovies()
        {
            // return the list of movies
            return View(Storage.Movies);
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
                Storage.AddMovie(response);
            }
            else
            {
                ViewBag.Message = "One or more inputs was invalid. The movie was not added to the list.";
            }

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
