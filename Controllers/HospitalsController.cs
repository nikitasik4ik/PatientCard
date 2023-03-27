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
    public class HospitalsController : Controller
    {
        private readonly PatientCardContext _context;

        public HospitalsController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: Hospitals
        public async Task<IActionResult> Index()
        {
            //var patientCardContext = _context.Hospital.Include(h => h.Departament).Include(h => h.InspectionHospital).Include(h => h.Operation).Include(h => h.Organization).Include(h => h.Reception).Include(h => h.User);
            //return View(await patientCardContext.ToListAsync());
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // получаем Id текущего пользователя
            var hospitals = await _context.Hospital
                .Where(t => t.UserId == userId)
                .Include(t => t.User)
                .ToListAsync();

            return View(hospitals);
        }

        // GET: Hospitals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital = await _context.Hospital
                .Include(h => h.Departament)
                .Include(h => h.InspectionHospital)
                .Include(h => h.Operation)
                .Include(h => h.Organization)
                .Include(h => h.Reception)
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.IdHospital == id);
            if (hospital == null)
            {
                return NotFound();
            }

            return View(hospital);
        }

        // GET: Hospitals/Create
        public IActionResult Create()
        {
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament");
            ViewData["InspectionHospitalId"] = new SelectList(_context.InspectionHospital, "IdInspectionHospital", "IdInspectionHospital");
            ViewData["IdOperation"] = new SelectList(_context.Operation, "IdOperation", "NameOperation");
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization");
            ViewData["IdReception"] = new SelectList(_context.Reception, "IdReception", "IdReception");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Hospitals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHospital,UserId,IdDepartament,IdOrganization,IdReception,InspectionHospitalId,DateReceipt,DateDischarge,Number,Ward,IdOperation")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", hospital.IdDepartament);
            ViewData["InspectionHospitalId"] = new SelectList(_context.InspectionHospital, "IdInspectionHospital", "IdInspectionHospital", hospital.InspectionHospitalId);
            ViewData["IdOperation"] = new SelectList(_context.Operation, "IdOperation", "IdOperation", hospital.IdOperation);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", hospital.IdOrganization);
            ViewData["IdReception"] = new SelectList(_context.Reception, "IdReception", "IdReception", hospital.IdReception);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", hospital.UserId);
            return View(hospital);
        }

        // GET: Hospitals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital = await _context.Hospital.FindAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", hospital.IdDepartament);
            ViewData["InspectionHospitalId"] = new SelectList(_context.InspectionHospital, "IdInspectionHospital", "IdInspectionHospital", hospital.InspectionHospitalId);
            ViewData["IdOperation"] = new SelectList(_context.Operation, "IdOperation", "IdOperation", hospital.IdOperation);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", hospital.IdOrganization);
            ViewData["IdReception"] = new SelectList(_context.Reception, "IdReception", "IdReception", hospital.IdReception);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", hospital.UserId);
            return View(hospital);
        }

        // POST: Hospitals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHospital,UserId,IdDepartament,IdOrganization,IdReception,InspectionHospitalId,DateReceipt,DateDischarge,Number,Ward,IdOperation")] Hospital hospital)
        {
            if (id != hospital.IdHospital)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospital);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospitalExists(hospital.IdHospital))
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
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", hospital.IdDepartament);
            ViewData["InspectionHospitalId"] = new SelectList(_context.InspectionHospital, "IdInspectionHospital", "IdInspectionHospital", hospital.InspectionHospitalId);
            ViewData["IdOperation"] = new SelectList(_context.Operation, "IdOperation", "IdOperation", hospital.IdOperation);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", hospital.IdOrganization);
            ViewData["IdReception"] = new SelectList(_context.Reception, "IdReception", "IdReception", hospital.IdReception);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", hospital.UserId);
            return View(hospital);
        }

        // GET: Hospitals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital = await _context.Hospital
                .Include(h => h.Departament)
                .Include(h => h.InspectionHospital)
                .Include(h => h.Operation)
                .Include(h => h.Organization)
                .Include(h => h.Reception)
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.IdHospital == id);
            if (hospital == null)
            {
                return NotFound();
            }

            return View(hospital);
        }

        // POST: Hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hospital == null)
            {
                return Problem("Entity set 'PatientCardContext.Hospital'  is null.");
            }
            var hospital = await _context.Hospital.FindAsync(id);
            if (hospital != null)
            {
                _context.Hospital.Remove(hospital);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospitalExists(int id)
        {
          return (_context.Hospital?.Any(e => e.IdHospital == id)).GetValueOrDefault();
        }
    }
}
