using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Identity.Infrastructure;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Identity.Controllers
{
    public class MuscleGroupController : Controller
    {
        private AppMuscleDbContext _context;
        private IMuscleGroupRepository muscleRepository;
        public MuscleGroupController(IMuscleGroupRepository repo, AppMuscleDbContext context)
        {
            muscleRepository = repo;
            _context = context;
        }



        public ViewResult Index() => View(muscleRepository.MuscleGroups);

        public ViewResult Create() => View();
        [HttpPost]
        public ViewResult Create(MuscleGroup muscleGroup)
        {
            if (ModelState.IsValid)
            {
                _context.MuscleGroup.Add(muscleGroup);
                _context.SaveChanges();

                
                    return View();
            }

            return View();
        }
        [HttpPost]
        public IActionResult Delete(int muscleGroupID) // delete from SpotMe
        {
            MuscleGroup deletedMuscle = muscleRepository.DeleteMuscle(muscleGroupID);
            if (deletedMuscle != null)
            {
                TempData["message"] = $"{deletedMuscle.muscle} was deleted";
            }
            return RedirectToAction("HandleMuscle");
        }
        public ViewResult HandleMuscle() => View(muscleRepository.MuscleGroups);



    }
}