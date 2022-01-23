using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MissionAssignment4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MissionAssignment4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieApplicationContext movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieApplicationContext movieData)
        {
            _logger = logger;
            movieContext = movieData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Movies(MovieApplicationResponse ar)
        {
            if (ar.Category == null)
            {
                return View("Movies");
            }
            else if (ar.Title == null)
            {
                return View("Movies");
            }
            else if ((ar.Year < 1800) || (ar.Year >= 2023))
            {
                return View("Movies");
            }
            else if (ar.Director == null)
            {
                return View("Movies");
            }
            else if (ar.Rating == null)
            {
                return View("Movies");
            }
            else
            {
                movieContext.Add(ar);
                movieContext.SaveChanges();

                return View("Confirmation", ar);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
