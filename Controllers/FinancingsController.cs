using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatientCard.Data;
using PatientCard.Models;

namespace PatientCard.Controllers
{
    public class FinancingsController : Controller
    {
        private readonly PatientCardContext _context;

        public FinancingsController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: Financings
        public async Task<IActionResult> Index()
        {
              return _context.Financing != null ? 
                          View(await _context.Financing.ToListAsync()) :
                          Problem("Entity set 'PatientCardContext.Financing'  is null.");
        }

        // GET: Financings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Financing == null)
            {
                return NotFound();
            }

            var financing = await _context.Financing
                .FirstOrDefaultAsync(m => m.IdFinancing == id);
            if (financing == null)
            {
                return NotFound();
            }

            return View(financing);
        }

        // GET: Financings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Financings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFinancing,FinancingName")] Financing financing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(financing);
        }

        // GET: Financings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Financing == null)
            {
                return NotFound();
            }

            var financing = await _context.Financing.FindAsync(id);
            if (financing == null)
            {
                return NotFound();
            }
            return View(financing);
        }

        // POST: Financings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFinancing,FinancingName")] Financing financing)
        {
            if (id != financing.IdFinancing)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinancingExists(financing.IdFinancing))
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
            return View(financing);
        }

        // GET: Financings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Financing == null)
            {
                return NotFound();
            }

            var financing = await _context.Financing
                .FirstOrDefaultAsync(m => m.IdFinancing == id);
            if (financing == null)
            {
                return NotFound();
            }

            return View(financing);
        }

        // POST: Financings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Financing == null)
            {
                return Problem("Entity set 'PatientCardContext.Financing'  is null.");
            }
            var financing = await _context.Financing.FindAsync(id);
            if (financing != null)
            {
                _context.Financing.Remove(financing);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinancingExists(int id)
        {
          return (_context.Financing?.Any(e => e.IdFinancing == id)).GetValueOrDefault();
        }
    }
}
