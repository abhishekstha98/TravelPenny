using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravPense.Data;
using TravPense.Models.DataBaseViewModels;

namespace TravPense.Controllers
{
    public class ActivityViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivityViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActivityViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivityViewModel.ToListAsync());
        }

        // GET: ActivityViewModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityViewModel = await _context.ActivityViewModel
                .SingleOrDefaultAsync(m => m.Activityid == id);
            if (activityViewModel == null)
            {
                return NotFound();
            }

            return View(activityViewModel);
        }

        // GET: ActivityViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActivityViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Activityid,ActivityName,Duration,LocationType,Price")] ActivityViewModel activityViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activityViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityViewModel);
        }

        // GET: ActivityViewModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityViewModel = await _context.ActivityViewModel.SingleOrDefaultAsync(m => m.Activityid == id);
            if (activityViewModel == null)
            {
                return NotFound();
            }
            return View(activityViewModel);
        }

        // POST: ActivityViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Activityid,ActivityName,Duration,LocationType,Price")] ActivityViewModel activityViewModel)
        {
            if (id != activityViewModel.Activityid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityViewModelExists(activityViewModel.Activityid))
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
            return View(activityViewModel);
        }

        // GET: ActivityViewModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityViewModel = await _context.ActivityViewModel
                .SingleOrDefaultAsync(m => m.Activityid == id);
            if (activityViewModel == null)
            {
                return NotFound();
            }

            return View(activityViewModel);
        }

        // POST: ActivityViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var activityViewModel = await _context.ActivityViewModel.SingleOrDefaultAsync(m => m.Activityid == id);
            _context.ActivityViewModel.Remove(activityViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityViewModelExists(string id)
        {
            return _context.ActivityViewModel.Any(e => e.Activityid == id);
        }
    }
}
