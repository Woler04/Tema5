using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Billiard.Data;

namespace Billiard.Controllers
{
    public class ReservationListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReservationLists
        public async Task<IActionResult> Index()
        {
              return View(await _context.ReservationList.ToListAsync());
        }

        // GET: ReservationLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReservationList == null)
            {
                return NotFound();
            }

            var reservationList = await _context.ReservationList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationList == null)
            {
                return NotFound();
            }

            return View(reservationList);
        }

        // GET: ReservationLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReservationLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Title")] ReservationList reservationList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservationList);
        }

        // GET: ReservationLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReservationList == null)
            {
                return NotFound();
            }

            var reservationList = await _context.ReservationList.FindAsync(id);
            if (reservationList == null)
            {
                return NotFound();
            }
            return View(reservationList);
        }

        // POST: ReservationLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Title")] ReservationList reservationList)
        {
            if (id != reservationList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationListExists(reservationList.Id))
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
            return View(reservationList);
        }

        // GET: ReservationLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReservationList == null)
            {
                return NotFound();
            }

            var reservationList = await _context.ReservationList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationList == null)
            {
                return NotFound();
            }

            return View(reservationList);
        }

        // POST: ReservationLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReservationList == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ReservationList'  is null.");
            }
            var reservationList = await _context.ReservationList.FindAsync(id);
            if (reservationList != null)
            {
                _context.ReservationList.Remove(reservationList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationListExists(int id)
        {
          return _context.ReservationList.Any(e => e.Id == id);
        }
    }
}
