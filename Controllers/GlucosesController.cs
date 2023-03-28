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
    public class GlucosesController : Controller
    {
        private readonly PatientCardContext _context;

        public GlucosesController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: Glucoses
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // получаем Id текущего пользователя
            var glucoses = await _context.Glucose
                .Where(t => t.UserId == userId)
                .Include(t => t.User)
                .ToListAsync();

            return View(glucoses);
        }

        // GET: Glucoses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Glucose == null)
            {
                return NotFound();
            }

            var glucose = await _context.Glucose
                .Include(g => g.User)
                .FirstOrDefaultAsync(m => m.GlucoseId == id);
            if (glucose == null)
            {
                return NotFound();
            }

            return View(glucose);
        }

        // GET: Glucoses/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View(new Glucose { UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) });
        }

        // POST: Glucoses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GlucoseId,Value,Date,UserId")] Glucose glucose)
        {
            if (ModelState.IsValid)
            {
                _context.Add(glucose);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PersonalAccount");
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", glucose.UserId);
            return View(glucose);
        }

        // GET: Glucoses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Glucose == null)
            {
                return NotFound();
            }

            var glucose = await _context.Glucose.FindAsync(id);
            if (glucose == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", glucose.UserId);
            return View(glucose);
        }

        // POST: Glucoses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GlucoseId,Value,Date,UserId")] Glucose glucose)
        {
            if (id != glucose.GlucoseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(glucose);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GlucoseExists(glucose.GlucoseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "PersonalAccount");
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", glucose.UserId);
            return View(glucose);
        }

        // GET: Glucoses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Glucose == null)
            {
                return NotFound();
            }

            var glucose = await _context.Glucose
                .Include(g => g.User)
                .FirstOrDefaultAsync(m => m.GlucoseId == id);
            if (glucose == null)
            {
                return NotFound();
            }

            return View(glucose);
        }

        // POST: Glucoses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Glucose == null)
            {
                return Problem("Entity set 'PatientCardContext.Glucose'  is null.");
            }
            var glucose = await _context.Glucose.FindAsync(id);
            if (glucose != null)
            {
                _context.Glucose.Remove(glucose);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "PersonalAccount");
        }

        private bool GlucoseExists(int id)
        {
          return (_context.Glucose?.Any(e => e.GlucoseId == id)).GetValueOrDefault();
        }
    }
}
