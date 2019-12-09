using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
    [Route("/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // [HttpGet()]
        [HttpGet("{id}")]
        public IActionResult Order (Pizza p)
        {
          ViewBag.Pizza = p;
          return View("Index", new Pizza());
        }

        public IActionResult Index()
        {
            // dynamic ViewBag1 = new Object();
            // ViewBag1.Name = id;
            // ViewBag.Name = id;
            // ViewData["Name"] = id;
            // TempData["Name"] = id;


            return View(new Pizza());
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
