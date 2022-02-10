using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
       
        private MovieApplicationContext movieContext { get; set; }

        public HomeController(MovieApplicationContext movieData)
        {
            movieContext = movieData;
        }

        // Show Index view
        public IActionResult Index()
        {
            return View();
        }

        // Show MyPodCasts view
        public IActionResult MyPodcasts()
        {
            return View();
        }

        // Show Adding Editing Movie data view
        [HttpGet]
        public IActionResult Movies()
        {
            // taking our database set and putting into a list format so we can look through it
            ViewBag.Categories = movieContext.Categories.ToList();

            return View();
        }

        // Send Movie information input to the database
        [HttpPost]
        public IActionResult Movies(MovieApplicationResponse ar)
        {
            // to see if user puts in correct input
            if (ModelState.IsValid)
            {
                movieContext.Add(ar);
                movieContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();

                return View(ar);
            }


            //if (ar.Category == null)
            //{
            //    return View("Movies");
            //}
            //else if (ar.Title == null)
            //{
            //    return View("Movies");
            //}
            //else if ((ar.Year < 1800) || (ar.Year >= 2023))
            //{
            //    return View("Movies");
            //}
            //else if (ar.Director == null)
            //{
            //    return View("Movies");
            //}
            //else if (ar.Rating == null)
            //{
            //    return View("Movies");
            //}
            //else
            //{
            //    movieContext.Add(ar);
            //    movieContext.SaveChanges();

            //    return View("Confirmation", ar);
            //}
        }

        // Show Movies Data in List
        public IActionResult MovieList()
        {
            var applications = movieContext.Responses
                .Include(x => x.Category)
                //.OrderBy(x => x.MovieName)
                .ToList();

            return View(applications);
        }
        
        // getting edit view with data
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var mApplication = movieContext.Responses.Single(x => x.MovieId == movieid);

            return View("Movies", mApplication);
        }

        // send editted data
        [HttpPost]
        public IActionResult Edit(MovieApplicationResponse blah)
        {
            movieContext.Update(blah);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        // getting delete view
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var mApplication = movieContext.Responses.Single(x => x.MovieId == movieid);

            return View(mApplication);
        }

        // confirming delete data
        [HttpPost]
        public IActionResult Delete(MovieApplicationResponse ar)
        {
            movieContext.Responses.Remove(ar);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
