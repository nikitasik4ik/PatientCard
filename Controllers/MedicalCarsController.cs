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
    public class MedicalCarsController : Controller
    {
        private readonly PatientCardContext _context;

        public MedicalCarsController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: MedicalCars
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            if (userRole == "Admin")
            {
                var patientCardContext = _context.MedicalCar.Include(m => m.Doctor).Include(m => m.User);
                return View(await patientCardContext.ToListAsync());
            }
            else
            {
                var patientCardContext = _context.MedicalCar
                    .Where(m => m.UserId == userId)
                    .Include(m => m.Doctor)
                    .Include(m => m.User);

                return View(await patientCardContext.ToListAsync());
            }
        }


        // GET: MedicalCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicalCar == null)
            {
                return NotFound();
            }

            var medicalCar = await _context.MedicalCar
                .Include(m => m.Doctor)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.IdMedicalCar == id);
            if (medicalCar == null)
            {
                return NotFound();
            }

            return View(medicalCar);
        }

        // GET: MedicalCars/Create
        public IActionResult Create()
        {
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "FullNameDoctor");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View();
        }

        // POST: MedicalCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedicalCar,UserId,DateMedicalCar,PlaceExit,ReasonExit,Diagnosis,ResultExit,IssueExit,IdDoctor")] MedicalCar medicalCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", medicalCar.IdDoctor);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", medicalCar.UserId);
            return View(medicalCar);
        }

        // GET: MedicalCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicalCar == null)
            {
                return NotFound();
            }

            var medicalCar = await _context.MedicalCar.FindAsync(id);
            if (medicalCar == null)
            {
                return NotFound();
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "FullNameDoctor", medicalCar.IdDoctor);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", medicalCar.UserId);
            return View(medicalCar);
        }

        // POST: MedicalCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedicalCar,UserId,DateMedicalCar,PlaceExit,ReasonExit,Diagnosis,ResultExit,IssueExit,IdDoctor")] MedicalCar medicalCar)
        {
            if (id != medicalCar.IdMedicalCar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalCarExists(medicalCar.IdMedicalCar))
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
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", medicalCar.IdDoctor);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", medicalCar.UserId);
            return View(medicalCar);
        }

        // GET: MedicalCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicalCar == null)
            {
                return NotFound();
            }

            var medicalCar = await _context.MedicalCar
                .Include(m => m.Doctor)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.IdMedicalCar == id);
            if (medicalCar == null)
            {
                return NotFound();
            }

            return View(medicalCar);
        }

        // POST: MedicalCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicalCar == null)
            {
                return Problem("Entity set 'PatientCardContext.MedicalCar'  is null.");
            }
            var medicalCar = await _context.MedicalCar.FindAsync(id);
            if (medicalCar != null)
            {
                _context.MedicalCar.Remove(medicalCar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalCarExists(int id)
        {
          return (_context.MedicalCar?.Any(e => e.IdMedicalCar == id)).GetValueOrDefault();
        }
    }
}
