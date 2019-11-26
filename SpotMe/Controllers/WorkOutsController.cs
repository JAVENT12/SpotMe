using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;

namespace Identity
{
   // [RequireHttps]
    public class WorkOutsController : Controller
    {
        private readonly AppWorkOutsDbContext _context;

        public WorkOutsController(AppWorkOutsDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admins")]
        // GET: WorkOuts
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkOuts.ToListAsync());
        }
        [Authorize(Roles = "Admins")]

        // GET: WorkOuts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOuts = await _context.WorkOuts
                .FirstOrDefaultAsync(m => m.WorkOutsID == id);
            if (workOuts == null)
            {
                return NotFound();
            }

            return View(workOuts);
        }
        [Authorize(Roles = "Admins")]

        // GET: WorkOuts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkOuts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admins")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkOutsID,muscleGroupID,title")] WorkOuts workOuts)
        {
            if (string.IsNullOrEmpty(workOuts.title))
            {
                ModelState.AddModelError(nameof(workOuts.title),
                "Please enter an exercise title");
            }
            if (ModelState.IsValid)
            {
                _context.Add(workOuts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workOuts);
        }
        [Authorize(Roles = "Admins")]
        // GET: WorkOuts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOuts = await _context.WorkOuts.FindAsync(id);
            if (workOuts == null)
            {
                return NotFound();
            }
            return View(workOuts);
        }

        // POST: WorkOuts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admins")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkOutsID,muscleGroupID,title")] WorkOuts workOuts)
        {
            if (id != workOuts.WorkOutsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOuts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOutsExists(workOuts.WorkOutsID))
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
            return View(workOuts);
        }
        [Authorize(Roles = "Admins")]
        // GET: WorkOuts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOuts = await _context.WorkOuts
                .FirstOrDefaultAsync(m => m.WorkOutsID == id);
            if (workOuts == null)
            {
                return NotFound();
            }

            return View(workOuts);
        }

        // POST: WorkOuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOuts = await _context.WorkOuts.FindAsync(id);
            _context.WorkOuts.Remove(workOuts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> MuscleGroup()
        {
            return View(await _context.WorkOuts.ToListAsync());
        }






        private bool WorkOutsExists(int id)
        {
            return _context.WorkOuts.Any(e => e.WorkOutsID == id);
        }
    }
}
