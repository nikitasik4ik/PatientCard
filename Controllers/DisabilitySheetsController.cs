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
    public class DisabilitySheetsController : Controller
    {
        private readonly PatientCardContext _context;

        public DisabilitySheetsController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: DisabilitySheets
        public async Task<IActionResult> Index()
        {
            //var patientCardContext = _context.DisabilitySheet.Include(d => d.Departament).Include(d => d.Doctor).Include(d => d.Organization).Include(d => d.User);
            //return View(await patientCardContext.ToListAsync());
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            if (userRole == "Admin")
            {
                var disabilitySheets = await _context.DisabilitySheet
                    .Include(d => d.Departament)
                    .Include(d => d.Doctor)
                    .Include(d => d.Organization)
                    .Include(d => d.User)
                    .ToListAsync();

                return View(disabilitySheets);
            }
            else
            {
                var disabilitySheets = await _context.DisabilitySheet
                    .Where(d => d.UserId == userId)
                    .Include(d => d.Departament)
                    .Include(d => d.Doctor)
                    .Include(d => d.Organization)
                    .Include(d => d.User)
                    .ToListAsync();

                return View(disabilitySheets);
            }
        }

        // GET: DisabilitySheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DisabilitySheet == null)
            {
                return NotFound();
            }

            var disabilitySheet = await _context.DisabilitySheet
                .Include(d => d.Departament)
                .Include(d => d.Doctor)
                .Include(d => d.Organization)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.IdDisabilitySheet == id);
            if (disabilitySheet == null)
            {
                return NotFound();
            }

            return View(disabilitySheet);
        }

        // GET: DisabilitySheets/Create
        public IActionResult Create()
        {
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "NameDepartament");
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "FullNameDoctor");
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View();
        }

        // POST: DisabilitySheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDisabilitySheet,UserId,IdDoctor,FromDate,ToDate,IdDepartament,IdOrganization,DateOfSinging,Reason")] DisabilitySheet disabilitySheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disabilitySheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", disabilitySheet.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", disabilitySheet.IdDoctor);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", disabilitySheet.IdOrganization);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", disabilitySheet.UserId);
            return View(disabilitySheet);
        }

        // GET: DisabilitySheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DisabilitySheet == null)
            {
                return NotFound();
            }

            var disabilitySheet = await _context.DisabilitySheet.FindAsync(id);
            if (disabilitySheet == null)
            {
                return NotFound();
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "NameDepartament", disabilitySheet.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "FullNameDoctor", disabilitySheet.IdDoctor);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "Name", disabilitySheet.IdOrganization);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", disabilitySheet.UserId);
            return View(disabilitySheet);
        }

        // POST: DisabilitySheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDisabilitySheet,UserId,IdDoctor,FromDate,ToDate,IdDepartament,IdOrganization,DateOfSinging,Reason")] DisabilitySheet disabilitySheet)
        {
            if (id != disabilitySheet.IdDisabilitySheet)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disabilitySheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisabilitySheetExists(disabilitySheet.IdDisabilitySheet))
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
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", disabilitySheet.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", disabilitySheet.IdDoctor);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", disabilitySheet.IdOrganization);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", disabilitySheet.UserId);
            return View(disabilitySheet);
        }

        // GET: DisabilitySheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DisabilitySheet == null)
            {
                return NotFound();
            }

            var disabilitySheet = await _context.DisabilitySheet
                .Include(d => d.Departament)
                .Include(d => d.Doctor)
                .Include(d => d.Organization)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.IdDisabilitySheet == id);
            if (disabilitySheet == null)
            {
                return NotFound();
            }

            return View(disabilitySheet);
        }

        // POST: DisabilitySheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DisabilitySheet == null)
            {
                return Problem("Entity set 'PatientCardContext.DisabilitySheet'  is null.");
            }
            var disabilitySheet = await _context.DisabilitySheet.FindAsync(id);
            if (disabilitySheet != null)
            {
                _context.DisabilitySheet.Remove(disabilitySheet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisabilitySheetExists(int id)
        {
          return (_context.DisabilitySheet?.Any(e => e.IdDisabilitySheet == id)).GetValueOrDefault();
        }
    }
}
