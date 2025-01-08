using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlacementTracker.Models;

namespace PlacementTracker.Controllers
{
    [Authorize]
    public class PlacementActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlacementActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlacementActivities
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlacementActivities.ToListAsync());
        }

        // GET: PlacementActivities/Report
        [Authorize]
        public IActionResult Report()
        {
            var activities = _context.PlacementActivities.ToList();
            return View(activities);
        }

        // GET: PlacementActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placementActivity = await _context.PlacementActivities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placementActivity == null)
            {
                return NotFound();
            }

            return View(placementActivity);
        }

        // GET: PlacementActivities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlacementActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActivityType,Description,Date")] PlacementActivity placementActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placementActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(placementActivity);
        }

        // GET: PlacementActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placementActivity = await _context.PlacementActivities.FindAsync(id);
            if (placementActivity == null)
            {
                return NotFound();
            }
            return View(placementActivity);
        }

        // POST: PlacementActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActivityType,Description,Date")] PlacementActivity placementActivity)
        {
            if (id != placementActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placementActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacementActivityExists(placementActivity.Id))
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
            return View(placementActivity);
        }

        // GET: PlacementActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placementActivity = await _context.PlacementActivities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placementActivity == null)
            {
                return NotFound();
            }

            return View(placementActivity);
        }

        // POST: PlacementActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placementActivity = await _context.PlacementActivities.FindAsync(id);
            if (placementActivity != null)
            {
                _context.PlacementActivities.Remove(placementActivity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacementActivityExists(int id)
        {
            return _context.PlacementActivities.Any(e => e.Id == id);
        }
    }
}
