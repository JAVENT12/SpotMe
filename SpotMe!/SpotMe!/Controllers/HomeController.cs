using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpotMe_.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography;

namespace SpotMe_.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private IExcerciserRepository repository;
        public HomeController(IExcerciserRepository repo, ApplicationDbContext context)
        {
            repository = repo;
            _context = context;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

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
        [HttpGet]
        public ViewResult Signup() => View();
        [HttpPost]
        public ViewResult Signup(Excerciser excerciser)
        {
          
             string name = excerciser.firstName;
             string password = excerciser.userPassword;
             excerciser.excerciserID = name.Length + 1001;
                 
            // excerciser.userPassword = class method to encrypt
            _context.Excerciser.Add(excerciser);
           
            _context.SaveChanges();
            return View();
            
        }

        private string Getmd5Hash(MD5 md5Hash, string userPassword)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ViewResult Create() => View();
        [HttpPost]
        public ViewResult Create(Excerciser excerciser)
        {
            string password = excerciser.userPassword; 
            excerciser.userPassword = Encrypt.CreateMD5(password);
            _context.Excerciser.Add(excerciser);
            _context.SaveChanges();
            return View();
        }
        public ViewResult MuscleGroup()
        {
            return View(repository.Excercisers);
        }
    
    }
}
