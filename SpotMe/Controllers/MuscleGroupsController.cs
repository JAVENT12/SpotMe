using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Identity.Infrastructure;


namespace Identity
{
    public class MuscleGroupsController : Controller
    {
        private readonly AppMuscleDbContext _context;
       // private IMuscleGroupRepository






        public MuscleGroupsController(AppMuscleDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admins")]
        // GET: MuscleGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.MuscleGroup.ToListAsync());
        }
        [Authorize(Roles = "Admins")]
        // GET: MuscleGroups/Details/5
        public async Task<IActionResult> Details(int? id)
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
        [Authorize(Roles = "Admins")]
        // GET: MuscleGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MuscleGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admins")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("muscleGroupID,WorkoutsID,name")] MuscleGroup muscleGroup)
        {
            //AppMuscleDbContext db = new AppMuscleDbContext();

         //   bool IsMuscleNameExist = db.MuscleGroup.Any
         //(x => x.muscle == muscleGroup.muscle && x.muscleGroupID != muscleGroup.muscleGroupID);

         //   if (IsMuscleNameExist == true)
         //   {
         //       ModelState.AddModelError("muscle", "muscle already exists");
         //   }


            if (string.IsNullOrEmpty(muscleGroup.name))
            {
                ModelState.AddModelError(nameof(muscleGroup.name),
                "Please enter a muscle");
            }
            //if (ModelState.GetFieldValidationState(nameof(muscleGroup.muscle))
            //    == ModelValidationState.Valid
            //    && muscleGroup.muscle.Contains("")) 
        
            if (ModelState.IsValid)
            {
                _context.Add(muscleGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(muscleGroup);
        }
        [Authorize(Roles = "Admins")]
        // GET: MuscleGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscleGroup = await _context.MuscleGroup.FindAsync(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }
            return View(muscleGroup);
        }

        // POST: MuscleGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admins")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("muscleGroupID,WorkoutsID,name")] MuscleGroup muscleGroup)
        {
            if (id != muscleGroup.muscleGroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(muscleGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MuscleGroupExists(muscleGroup.muscleGroupID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(muscleGroup);
        }
        [Authorize(Roles = "Admins")]
        // GET: MuscleGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
        [Authorize(Roles = "Admins")]
        // POST: MuscleGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var muscleGroup = await _context.MuscleGroup.FindAsync(id);
            _context.MuscleGroup.Remove(muscleGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Excercises()
        {
            return View(await _context.MuscleGroup.ToListAsync());
        }
        public async Task<IActionResult> Description(int? id)
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

        private bool MuscleGroupExists(int id)
        {
            return _context.MuscleGroup.Any(e => e.muscleGroupID == id);
        }
    }
}
