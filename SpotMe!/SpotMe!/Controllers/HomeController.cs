using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpotMe_.Models;

namespace SpotMe_.Controllers
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

        public IActionResult Help()
        {
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }

    
    }
}
