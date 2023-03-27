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
    public class InspectionHospitalsController : Controller
    {
        private readonly PatientCardContext _context;

        public InspectionHospitalsController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: InspectionHospitals
        public async Task<IActionResult> Index()
        {
            var patientCardContext = _context.InspectionHospital.Include(i => i.Departament).Include(i => i.Doctor).Include(i => i.Service).Include(i => i.User);
            return View(await patientCardContext.ToListAsync());
        }

        // GET: InspectionHospitals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InspectionHospital == null)
            {
                return NotFound();
            }

            var inspectionHospital = await _context.InspectionHospital
                .Include(i => i.Departament)
                .Include(i => i.Doctor)
                .Include(i => i.Service)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.IdInspectionHospital == id);
            if (inspectionHospital == null)
            {
                return NotFound();
            }

            return View(inspectionHospital);
        }

        // GET: InspectionHospitals/Create
        public IActionResult Create()
        {
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament");
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor");
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: InspectionHospitals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInspectionHospital,UserId,IdDepartament,IdDoctor,IdService,InspectionPlan,Complaint,Inspection")] InspectionHospital inspectionHospital)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspectionHospital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", inspectionHospital.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", inspectionHospital.IdDoctor);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService", inspectionHospital.IdService);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", inspectionHospital.UserId);
            return View(inspectionHospital);
        }

        // GET: InspectionHospitals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InspectionHospital == null)
            {
                return NotFound();
            }

            var inspectionHospital = await _context.InspectionHospital.FindAsync(id);
            if (inspectionHospital == null)
            {
                return NotFound();
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", inspectionHospital.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", inspectionHospital.IdDoctor);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService", inspectionHospital.IdService);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", inspectionHospital.UserId);
            return View(inspectionHospital);
        }

        // POST: InspectionHospitals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInspectionHospital,UserId,IdDepartament,IdDoctor,IdService,InspectionPlan,Complaint,Inspection")] InspectionHospital inspectionHospital)
        {
            if (id != inspectionHospital.IdInspectionHospital)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspectionHospital);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspectionHospitalExists(inspectionHospital.IdInspectionHospital))
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
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", inspectionHospital.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", inspectionHospital.IdDoctor);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService", inspectionHospital.IdService);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", inspectionHospital.UserId);
            return View(inspectionHospital);
        }

        // GET: InspectionHospitals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InspectionHospital == null)
            {
                return NotFound();
            }

            var inspectionHospital = await _context.InspectionHospital
                .Include(i => i.Departament)
                .Include(i => i.Doctor)
                .Include(i => i.Service)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.IdInspectionHospital == id);
            if (inspectionHospital == null)
            {
                return NotFound();
            }

            return View(inspectionHospital);
        }

        // POST: InspectionHospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InspectionHospital == null)
            {
                return Problem("Entity set 'PatientCardContext.InspectionHospital'  is null.");
            }
            var inspectionHospital = await _context.InspectionHospital.FindAsync(id);
            if (inspectionHospital != null)
            {
                _context.InspectionHospital.Remove(inspectionHospital);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspectionHospitalExists(int id)
        {
          return (_context.InspectionHospital?.Any(e => e.IdInspectionHospital == id)).GetValueOrDefault();
        }
    }
}
