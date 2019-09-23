using Microsoft.AspNetCore.Mvc;
using SpotMe_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotMe_.Controllers
{
    public class ExcerciserController : Controller
    {
        private IExcerciserRepository repository;

        public ExcerciserController(IExcerciserRepository repo)
        {
            repository = repo;
        }
        // public ViewResult someView() => View(repository.Products);
    }
}
