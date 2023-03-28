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
    public class PressuresController : Controller
    {
        private readonly PatientCardContext _context;

        public PressuresController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: Pressures
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // получаем Id текущего пользователя
            var pressures = await _context.Pressure
                .Where(t => t.UserId == userId)
                .Include(t => t.User)
                .ToListAsync();

            return View(pressures);
        }

        // GET: Pressures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pressure == null)
            {
                return NotFound();
            }

            var pressure = await _context.Pressure
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PressureId == id);
            if (pressure == null)
            {
                return NotFound();
            }

            return View(pressure);
        }

        // GET: Pressures/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View(new Pressure { UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) });
        }

        // POST: Pressures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PressureId,Value,Date,UserId")] Pressure pressure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pressure);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PersonalAccount");
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", pressure.UserId);
            return View(pressure);
        }

        // GET: Pressures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pressure == null)
            {
                return NotFound();
            }

            var pressure = await _context.Pressure.FindAsync(id);
            if (pressure == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", pressure.UserId);
            return View(pressure);
        }

        // POST: Pressures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PressureId,Value,Date,UserId")] Pressure pressure)
        {
            if (id != pressure.PressureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pressure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PressureExists(pressure.PressureId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", pressure.UserId);
            return View(pressure);
        }

        // GET: Pressures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pressure == null)
            {
                return NotFound();
            }

            var pressure = await _context.Pressure
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PressureId == id);
            if (pressure == null)
            {
                return NotFound();
            }

            return View(pressure);
        }

        // POST: Pressures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pressure == null)
            {
                return Problem("Entity set 'PatientCardContext.Pressure'  is null.");
            }
            var pressure = await _context.Pressure.FindAsync(id);
            if (pressure != null)
            {
                _context.Pressure.Remove(pressure);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "PersonalAccount");
        }

        private bool PressureExists(int id)
        {
          return (_context.Pressure?.Any(e => e.PressureId == id)).GetValueOrDefault();
        }
    }
}
