using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identity.Models;
using Identity.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Identity.Infrastructure;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Identity.Controllers
{
    public class RoutineController : Controller
    {
        // GET: /<controller>/
        private IMuscleGroupRepository repository;
        private readonly AppMuscleDbContext _context;
        private Routine routine;
        private UserManager<AppUser> userManager;
        private IRoutineRepository repos;
        private RoutineDbContext context_;

        public RoutineController(IMuscleGroupRepository repo, AppMuscleDbContext context, Routine routineService, UserManager<AppUser> usrMgr, IRoutineRepository reposi, RoutineDbContext context__)
        {
            userManager = usrMgr;
            _context = context;
            repository = repo;
            routine = routineService;
            reposi = repos;
            context__ = context_;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new WorkOutIndexViewModel
            {


                Routine = GetRoutine(),

                ReturnUrl = returnUrl

            });
        }
        public async Task<IActionResult> RoutineList() =>  ///////Routines!!!
                View(await context_.Routines.ToListAsync()
                 );
        public async Task<IActionResult> UserRoutine(string returnUrl, string UserName)
        {
           
            Routine routine = await context_.Routines.FindAsync(UserName);
            return View(new WorkOutIndexViewModel
            {
                Routine = GetRoutine(),
                   
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToRoutine(int muscleGroupID, string returnUrl)
        {
            MuscleGroup muscleGroup = repository.MuscleGroups
                .FirstOrDefault(m => m.muscleGroupID == muscleGroupID);
            //if (User?.Identity?.IsAuthenticated ?? true)
            //{
            //    routine.UserName = User.Identity.Name;       // save routines to a user's username
            //    routine.AddExercise(muscleGroup, 1);
            //    context_.Routines.Add(routine);
            //    context_.SaveChanges();
            //    return RedirectToAction("UserRoutine", new { returnUrl });
            //}
            if(muscleGroup != null)
            {

                routine.AddExercise(muscleGroup, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromRoutine(int muscleGroupId, string returnUrl)
        {
            MuscleGroup muscleGroup = repository.MuscleGroups
                .FirstOrDefault(m => m.muscleGroupID == muscleGroupId);

            if(muscleGroup != null)
            {
                routine.RemoveLine(muscleGroup);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Routine GetRoutine()
        {
            if (User?.Identity?.IsAuthenticated ?? true)
            {
                Routine routine = HttpContext.Session.GetJson<Routine>("Routine") ?? new Routine();
                    routine.UserName = User.Identity.Name;       // save routines to a user's username??       
                    context_.Routines.Add(routine);
                    context_.SaveChanges();
                return routine;
            }
            else
            {
                Routine routine = HttpContext.Session.GetJson<Routine>("Routine") ?? new Routine();
                return routine;
            }
            
        }
        private void SaveRoutine(Routine routine)
        {
            if (User?.Identity?.IsAuthenticated ?? true)
            {
                HttpContext.Session.SetJson("Routine", routine); // change for permanent routines
            }
            else
            {
                HttpContext.Session.SetJson("Routine", routine); 
            }
            
        }
        public async Task<IActionResult> Description(int? id) // Implement here?
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscleGroup = await _context.MuscleGroup
                .FirstOrDefaultAsync(m => m.muscleGroupID == id);
            if (muscleGroup == null)
            {
                return NotFound();
            }

            return View(muscleGroup);
        }
        public async Task<IActionResult> UserDescription(int? id) // Implement here?
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscleGroup = await _context.MuscleGroup
                .FirstOrDefaultAsync(m => m.muscleGroupID == id);
            if (muscleGroup == null)
            {
                return NotFound();
            }

            return View(muscleGroup);
        }
    }
}
