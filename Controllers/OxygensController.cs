using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatientCard.Data;
using PatientCard.Models;

namespace PatientCard.Controllers
{
    public class OxygensController : Controller
    {
        private readonly PatientCardContext _context;

        public OxygensController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: Oxygens
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // получаем Id текущего пользователя
            var oxygens = await _context.Oxygen
                .Where(t => t.UserId == userId)
                .Include(t => t.User)
                .ToListAsync();

            return View(oxygens);
        }

        // GET: Oxygens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Oxygen == null)
            {
                return NotFound();
            }

            var oxygen = await _context.Oxygen
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OxygenId == id);
            if (oxygen == null)
            {
                return NotFound();
            }

            return View(oxygen);
        }

        // GET: Oxygens/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View(new Oxygen { UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) });
        }

        // POST: Oxygens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OxygenId,Value,Date,UserId")] Oxygen oxygen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oxygen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", oxygen.UserId);
            return View(oxygen);
        }

        // GET: Oxygens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Oxygen == null)
            {
                return NotFound();
            }

            var oxygen = await _context.Oxygen.FindAsync(id);
            if (oxygen == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", oxygen.UserId);
            return View(oxygen);
        }

        // POST: Oxygens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OxygenId,Value,Date,UserId")] Oxygen oxygen)
        {
            if (id != oxygen.OxygenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oxygen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OxygenExists(oxygen.OxygenId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", oxygen.UserId);
            return View(oxygen);
        }

        // GET: Oxygens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Oxygen == null)
            {
                return NotFound();
            }

            var oxygen = await _context.Oxygen
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OxygenId == id);
            if (oxygen == null)
            {
                return NotFound();
            }

            return View(oxygen);
        }

        // POST: Oxygens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Oxygen == null)
            {
                return Problem("Entity set 'PatientCardContext.Oxygen'  is null.");
            }
            var oxygen = await _context.Oxygen.FindAsync(id);
            if (oxygen != null)
            {
                _context.Oxygen.Remove(oxygen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OxygenExists(int id)
        {
          return (_context.Oxygen?.Any(e => e.OxygenId == id)).GetValueOrDefault();
        }
    }
}
