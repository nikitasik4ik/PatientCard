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
    public class StydiesController : Controller
    {
        private readonly PatientCardContext _context;

        public StydiesController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: Stydies
        public async Task<IActionResult> Index()
        {
            var patientCardContext = _context.Stydy.Include(s => s.Departament).Include(s => s.Doctor).Include(s => s.Organization).Include(s => s.User);
            return View(await patientCardContext.ToListAsync());
        }

        // GET: Stydies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stydy == null)
            {
                return NotFound();
            }

            var stydy = await _context.Stydy
                .Include(s => s.Departament)
                .Include(s => s.Doctor)
                .Include(s => s.Organization)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.IdStydy == id);
            if (stydy == null)
            {
                return NotFound();
            }

            return View(stydy);
        }

        // GET: Stydies/Create
        public IActionResult Create()
        {
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "NameDepartament");
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "FullNameDoctor");
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View();
        }

        // POST: Stydies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStydy,IdDepartament,IdOrganization,Number,UserId,Date,Done,Protocol,Conclusion,IdDoctor")] Stydy stydy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stydy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", stydy.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", stydy.IdDoctor);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", stydy.IdOrganization);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", stydy.UserId);
            return View(stydy);
        }

        // GET: Stydies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stydy == null)
            {
                return NotFound();
            }

            var stydy = await _context.Stydy.FindAsync(id);
            if (stydy == null)
            {
                return NotFound();
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "NameDepartament", stydy.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "FullNameDoctor", stydy.IdDoctor);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "Name", stydy.IdOrganization);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", stydy.UserId);
            return View(stydy);
        }

        // POST: Stydies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStydy,IdDepartament,IdOrganization,Number,UserId,Date,Done,Protocol,Conclusion,IdDoctor")] Stydy stydy)
        {
            if (id != stydy.IdStydy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stydy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StydyExists(stydy.IdStydy))
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
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", stydy.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", stydy.IdDoctor);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", stydy.IdOrganization);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", stydy.UserId);
            return View(stydy);
        }

        // GET: Stydies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stydy == null)
            {
                return NotFound();
            }

            var stydy = await _context.Stydy
                .Include(s => s.Departament)
                .Include(s => s.Doctor)
                .Include(s => s.Organization)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.IdStydy == id);
            if (stydy == null)
            {
                return NotFound();
            }

            return View(stydy);
        }

        // POST: Stydies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stydy == null)
            {
                return Problem("Entity set 'PatientCardContext.Stydy'  is null.");
            }
            var stydy = await _context.Stydy.FindAsync(id);
            if (stydy != null)
            {
                _context.Stydy.Remove(stydy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StydyExists(int id)
        {
          return (_context.Stydy?.Any(e => e.IdStydy == id)).GetValueOrDefault();
        }
    }
}
