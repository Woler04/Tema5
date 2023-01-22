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
    public class BilliardTablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BilliardTablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BilliardTables
        public async Task<IActionResult> Index()
        {
              return View(await _context.BilliardTable.ToListAsync());
        }

        // GET: BilliardTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BilliardTable == null)
            {
                return NotFound();
            }

            var billiardTable = await _context.BilliardTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billiardTable == null)
            {
                return NotFound();
            }

            return View(billiardTable);
        }

        // GET: BilliardTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BilliardTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Spaces,isForSmokers")] BilliardTable billiardTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billiardTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(billiardTable);
        }

        // GET: BilliardTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BilliardTable == null)
            {
                return NotFound();
            }

            var billiardTable = await _context.BilliardTable.FindAsync(id);
            if (billiardTable == null)
            {
                return NotFound();
            }
            return View(billiardTable);
        }

        // POST: BilliardTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Spaces,isForSmokers")] BilliardTable billiardTable)
        {
            if (id != billiardTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billiardTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BilliardTableExists(billiardTable.Id))
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
            return View(billiardTable);
        }

        // GET: BilliardTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BilliardTable == null)
            {
                return NotFound();
            }

            var billiardTable = await _context.BilliardTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billiardTable == null)
            {
                return NotFound();
            }

            return View(billiardTable);
        }

        // POST: BilliardTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BilliardTable == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BilliardTable'  is null.");
            }
            var billiardTable = await _context.BilliardTable.FindAsync(id);
            if (billiardTable != null)
            {
                _context.BilliardTable.Remove(billiardTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BilliardTableExists(int id)
        {
          return _context.BilliardTable.Any(e => e.Id == id);
        }
    }
}
