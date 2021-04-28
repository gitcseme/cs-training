using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieData.Contexts;
using MovieData.Entities;
using MovieTracker.CachingHelpers;
using MovieTracker.Models;
using MovieTracker.Validations;

namespace MovieTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieContext dbContext;

        public HomeController(ILogger<HomeController> logger, MovieContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        [ServiceFilter(typeof(RedisMovieCachingFilter))]
        public async Task<IActionResult> Index()
        {
            //var movie = new Movie { Name = "Iron Man 3", Image = "https://miro.medium.com/max/3360/1*2BXuHrr37-INSlfwujBK0w.jpeg" };
            // dbContext.Movies.Add(movie);
            // dbContext.SaveChanges();
            
            await Task.Delay(3000);

            var movie = await Task.Run(() => {
                return dbContext.Movies
                    .Where(m => m.Name == "Iron Man 3")
                    .Include(m => m.Actors)
                    .FirstOrDefault();
            });

            return View(movie);
        }

        [HttpGet]
        public  IActionResult CreateMovie() 
        {
            return View();
        }

        [HttpPost]
        [ServiceFilter(typeof(MovieValidationFilterAttribute))]
        public async Task<IActionResult> CreateMovie(MovieCreateViewModel model) 
        {
            var movie = new Movie {
                Name = model.Name,
                Image = model.Image
            };

            await dbContext.Movies.AddAsync(movie);

            return RedirectToAction("Index");
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
