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
    public class PolyclinicsController : Controller
    {
        private readonly PatientCardContext _context;

        public PolyclinicsController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: Polyclinics
        public async Task<IActionResult> Index()
        {
            var patientCardContext = _context.Polyclinic.Include(p => p.Analyze).Include(p => p.Departament).Include(p => p.Financing).Include(p => p.InspectionPolyclinic).Include(p => p.Organization).Include(p => p.Stydy).Include(p => p.User);
            return View(await patientCardContext.ToListAsync());
        }

        // GET: Polyclinics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Polyclinic == null)
            {
                return NotFound();
            }

            var polyclinic = await _context.Polyclinic
                .Include(p => p.Analyze)
                .Include(p => p.Departament)
                .Include(p => p.Financing)
                .Include(p => p.InspectionPolyclinic)
                .Include(p => p.Organization)
                .Include(p => p.Stydy)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.IdPolyclinic == id);
            if (polyclinic == null)
            {
                return NotFound();
            }

            return View(polyclinic);
        }

        // GET: Polyclinics/Create
        public IActionResult Create()
        {
            ViewData["IdAnalyze"] = new SelectList(_context.Analyze, "IdAnalyzes", "IdAnalyzes");
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament");
            ViewData["IdFinancing"] = new SelectList(_context.Financing, "IdFinancing", "IdFinancing");
            ViewData["InspectionPolyclinicId"] = new SelectList(_context.InspectionPoliclinics, "IdInspectionPoliclinic", "IdInspectionPoliclinic");
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization");
            ViewData["IdStydy"] = new SelectList(_context.Stydy, "IdStydy", "IdStydy");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Polyclinics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPolyclinic,UserId,Date,IdDepartament,IdOrganization,Complaints,Reason,InspectionPolyclinicId,IdFinancing,Conditions,IdAnalyze,IdStydy")] Polyclinic polyclinic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(polyclinic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAnalyze"] = new SelectList(_context.Analyze, "IdAnalyzes", "IdAnalyzes", polyclinic.IdAnalyze);
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", polyclinic.IdDepartament);
            ViewData["IdFinancing"] = new SelectList(_context.Financing, "IdFinancing", "IdFinancing", polyclinic.IdFinancing);
            ViewData["InspectionPolyclinicId"] = new SelectList(_context.InspectionPoliclinics, "IdInspectionPoliclinic", "IdInspectionPoliclinic", polyclinic.InspectionPolyclinicId);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", polyclinic.IdOrganization);
            ViewData["IdStydy"] = new SelectList(_context.Stydy, "IdStydy", "IdStydy", polyclinic.IdStydy);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", polyclinic.UserId);
            return View(polyclinic);
        }

        // GET: Polyclinics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Polyclinic == null)
            {
                return NotFound();
            }

            var polyclinic = await _context.Polyclinic.FindAsync(id);
            if (polyclinic == null)
            {
                return NotFound();
            }
            ViewData["IdAnalyze"] = new SelectList(_context.Analyze, "IdAnalyzes", "IdAnalyzes", polyclinic.IdAnalyze);
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", polyclinic.IdDepartament);
            ViewData["IdFinancing"] = new SelectList(_context.Financing, "IdFinancing", "IdFinancing", polyclinic.IdFinancing);
            ViewData["InspectionPolyclinicId"] = new SelectList(_context.InspectionPoliclinics, "IdInspectionPoliclinic", "IdInspectionPoliclinic", polyclinic.InspectionPolyclinicId);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", polyclinic.IdOrganization);
            ViewData["IdStydy"] = new SelectList(_context.Stydy, "IdStydy", "IdStydy", polyclinic.IdStydy);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", polyclinic.UserId);
            return View(polyclinic);
        }

        // POST: Polyclinics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPolyclinic,UserId,Date,IdDepartament,IdOrganization,Complaints,Reason,InspectionPolyclinicId,IdFinancing,Conditions,IdAnalyze,IdStydy")] Polyclinic polyclinic)
        {
            if (id != polyclinic.IdPolyclinic)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(polyclinic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolyclinicExists(polyclinic.IdPolyclinic))
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
            ViewData["IdAnalyze"] = new SelectList(_context.Analyze, "IdAnalyzes", "IdAnalyzes", polyclinic.IdAnalyze);
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", polyclinic.IdDepartament);
            ViewData["IdFinancing"] = new SelectList(_context.Financing, "IdFinancing", "IdFinancing", polyclinic.IdFinancing);
            ViewData["InspectionPolyclinicId"] = new SelectList(_context.InspectionPoliclinics, "IdInspectionPoliclinic", "IdInspectionPoliclinic", polyclinic.InspectionPolyclinicId);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", polyclinic.IdOrganization);
            ViewData["IdStydy"] = new SelectList(_context.Stydy, "IdStydy", "IdStydy", polyclinic.IdStydy);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", polyclinic.UserId);
            return View(polyclinic);
        }

        // GET: Polyclinics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Polyclinic == null)
            {
                return NotFound();
            }

            var polyclinic = await _context.Polyclinic
                .Include(p => p.Analyze)
                .Include(p => p.Departament)
                .Include(p => p.Financing)
                .Include(p => p.InspectionPolyclinic)
                .Include(p => p.Organization)
                .Include(p => p.Stydy)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.IdPolyclinic == id);
            if (polyclinic == null)
            {
                return NotFound();
            }

            return View(polyclinic);
        }

        // POST: Polyclinics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Polyclinic == null)
            {
                return Problem("Entity set 'PatientCardContext.Polyclinic'  is null.");
            }
            var polyclinic = await _context.Polyclinic.FindAsync(id);
            if (polyclinic != null)
            {
                _context.Polyclinic.Remove(polyclinic);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolyclinicExists(int id)
        {
          return (_context.Polyclinic?.Any(e => e.IdPolyclinic == id)).GetValueOrDefault();
        }
    }
}
