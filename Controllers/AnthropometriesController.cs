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
    public class AnthropometriesController : Controller
    {
        private readonly PatientCardContext _context;

        public AnthropometriesController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: Anthropometries
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // получаем Id текущего пользователя
            var anthropometries = await _context.Anthropometry
                .Where(t => t.UserId == userId)
                .Include(t => t.User)
                .ToListAsync();

            return View(anthropometries);
        }

        // GET: Anthropometries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Anthropometry == null)
            {
                return NotFound();
            }

            var anthropometry = await _context.Anthropometry
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AnthropometryId == id);
            if (anthropometry == null)
            {
                return NotFound();
            }

            return View(anthropometry);
        }

        // GET: Anthropometries/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View(new Anthropometry { UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) });
        }

        // POST: Anthropometries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnthropometryId,Value,Date,UserId")] Anthropometry anthropometry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anthropometry);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PersonalAccount");
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", anthropometry.UserId);
            return View(anthropometry);
        }

        // GET: Anthropometries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Anthropometry == null)
            {
                return NotFound();
            }

            var anthropometry = await _context.Anthropometry.FindAsync(id);
            if (anthropometry == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", anthropometry.UserId);
            return View(anthropometry);
        }

        // POST: Anthropometries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnthropometryId,Value,Date,UserId")] Anthropometry anthropometry)
        {
            if (id != anthropometry.AnthropometryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anthropometry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnthropometryExists(anthropometry.AnthropometryId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", anthropometry.UserId);
            return View(anthropometry);
        }

        // GET: Anthropometries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Anthropometry == null)
            {
                return NotFound();
            }

            var anthropometry = await _context.Anthropometry
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AnthropometryId == id);
            if (anthropometry == null)
            {
                return NotFound();
            }

            return View(anthropometry);
        }

        // POST: Anthropometries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Anthropometry == null)
            {
                return Problem("Entity set 'PatientCardContext.Anthropometry'  is null.");
            }
            var anthropometry = await _context.Anthropometry.FindAsync(id);
            if (anthropometry != null)
            {
                _context.Anthropometry.Remove(anthropometry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "PersonalAccount");
        }

        private bool AnthropometryExists(int id)
        {
          return (_context.Anthropometry?.Any(e => e.AnthropometryId == id)).GetValueOrDefault();
        }
    }
}
