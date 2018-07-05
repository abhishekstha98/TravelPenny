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
    public class HotelViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HotelViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.HotelViewModel.ToListAsync());
        }

        // GET: HotelViewModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelViewModel = await _context.HotelViewModel
                .SingleOrDefaultAsync(m => m.HotelId == id);
            if (hotelViewModel == null)
            {
                return NotFound();
            }

            return View(hotelViewModel);
        }

        // GET: HotelViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotelViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelId,HotelName,Destinatino,Contact,MinPPP,MaxPPP")] HotelViewModel hotelViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelViewModel);
        }

        // GET: HotelViewModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelViewModel = await _context.HotelViewModel.SingleOrDefaultAsync(m => m.HotelId == id);
            if (hotelViewModel == null)
            {
                return NotFound();
            }
            return View(hotelViewModel);
        }

        // POST: HotelViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HotelId,HotelName,Destinatino,Contact,MinPPP,MaxPPP")] HotelViewModel hotelViewModel)
        {
            if (id != hotelViewModel.HotelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelViewModelExists(hotelViewModel.HotelId))
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
            return View(hotelViewModel);
        }

        // GET: HotelViewModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelViewModel = await _context.HotelViewModel
                .SingleOrDefaultAsync(m => m.HotelId == id);
            if (hotelViewModel == null)
            {
                return NotFound();
            }

            return View(hotelViewModel);
        }

        // POST: HotelViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hotelViewModel = await _context.HotelViewModel.SingleOrDefaultAsync(m => m.HotelId == id);
            _context.HotelViewModel.Remove(hotelViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelViewModelExists(string id)
        {
            return _context.HotelViewModel.Any(e => e.HotelId == id);
        }
    }
}
