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
    public class InspectionPolyclinicsController : Controller
    {
        private readonly PatientCardContext _context;

        public InspectionPolyclinicsController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: InspectionPolyclinics
        public async Task<IActionResult> Index()
        {
            var patientCardContext = _context.InspectionPoliclinics.Include(i => i.Departament).Include(i => i.Doctor).Include(i => i.Service).Include(i => i.User);
            return View(await patientCardContext.ToListAsync());
        }

        // GET: InspectionPolyclinics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InspectionPoliclinics == null)
            {
                return NotFound();
            }

            var inspectionPolyclinic = await _context.InspectionPoliclinics
                .Include(i => i.Departament)
                .Include(i => i.Doctor)
                .Include(i => i.Service)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.IdInspectionPoliclinic == id);
            if (inspectionPolyclinic == null)
            {
                return NotFound();
            }

            return View(inspectionPolyclinic);
        }

        // GET: InspectionPolyclinics/Create
        public IActionResult Create()
        {
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament");
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor");
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: InspectionPolyclinics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInspectionPoliclinic,UserId,IdDepartament,IdDoctor,IdService,Complaints,AnamnesisDisease,Diagnosis,Recommendation")] InspectionPolyclinic inspectionPolyclinic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspectionPolyclinic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", inspectionPolyclinic.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", inspectionPolyclinic.IdDoctor);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService", inspectionPolyclinic.IdService);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", inspectionPolyclinic.UserId);
            return View(inspectionPolyclinic);
        }

        // GET: InspectionPolyclinics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InspectionPoliclinics == null)
            {
                return NotFound();
            }

            var inspectionPolyclinic = await _context.InspectionPoliclinics.FindAsync(id);
            if (inspectionPolyclinic == null)
            {
                return NotFound();
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", inspectionPolyclinic.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", inspectionPolyclinic.IdDoctor);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService", inspectionPolyclinic.IdService);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", inspectionPolyclinic.UserId);
            return View(inspectionPolyclinic);
        }

        // POST: InspectionPolyclinics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInspectionPoliclinic,UserId,IdDepartament,IdDoctor,IdService,Complaints,AnamnesisDisease,Diagnosis,Recommendation")] InspectionPolyclinic inspectionPolyclinic)
        {
            if (id != inspectionPolyclinic.IdInspectionPoliclinic)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspectionPolyclinic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspectionPolyclinicExists(inspectionPolyclinic.IdInspectionPoliclinic))
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
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", inspectionPolyclinic.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", inspectionPolyclinic.IdDoctor);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService", inspectionPolyclinic.IdService);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", inspectionPolyclinic.UserId);
            return View(inspectionPolyclinic);
        }

        // GET: InspectionPolyclinics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InspectionPoliclinics == null)
            {
                return NotFound();
            }

            var inspectionPolyclinic = await _context.InspectionPoliclinics
                .Include(i => i.Departament)
                .Include(i => i.Doctor)
                .Include(i => i.Service)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.IdInspectionPoliclinic == id);
            if (inspectionPolyclinic == null)
            {
                return NotFound();
            }

            return View(inspectionPolyclinic);
        }

        // POST: InspectionPolyclinics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InspectionPoliclinics == null)
            {
                return Problem("Entity set 'PatientCardContext.InspectionPoliclinics'  is null.");
            }
            var inspectionPolyclinic = await _context.InspectionPoliclinics.FindAsync(id);
            if (inspectionPolyclinic != null)
            {
                _context.InspectionPoliclinics.Remove(inspectionPolyclinic);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspectionPolyclinicExists(int id)
        {
          return (_context.InspectionPoliclinics?.Any(e => e.IdInspectionPoliclinic == id)).GetValueOrDefault();
        }
    }
}
