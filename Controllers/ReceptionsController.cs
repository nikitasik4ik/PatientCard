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
    public class ReceptionsController : Controller
    {
        private readonly PatientCardContext _context;

        public ReceptionsController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: Receptions
        public async Task<IActionResult> Index()
        {
            var patientCardContext = _context.Reception.Include(r => r.Analyze).Include(r => r.Departament).Include(r => r.Doctor).Include(r => r.Service).Include(r => r.Stydy);
            return View(await patientCardContext.ToListAsync());
        }

        // GET: Receptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reception == null)
            {
                return NotFound();
            }

            var reception = await _context.Reception
                .Include(r => r.Analyze)
                .Include(r => r.Departament)
                .Include(r => r.Doctor)
                .Include(r => r.Service)
                .Include(r => r.Stydy)
                .FirstOrDefaultAsync(m => m.IdReception == id);
            if (reception == null)
            {
                return NotFound();
            }

            return View(reception);
        }

        // GET: Receptions/Create
        public IActionResult Create()
        {
            ViewData["IdAnalyze"] = new SelectList(_context.Analyze, "IdAnalyzes", "IdAnalyzes");
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament");
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor");
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService");
            ViewData["IdStydy"] = new SelectList(_context.Stydy, "IdStydy", "IdStydy");
            return View();
        }

        // POST: Receptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReception,Date,IdDepartament,IdDoctor,IdService,Diagnosis,Complaints,IdAnalyze,IdStydy,TreatmentPlan,AnamnesisDisease,AnamnesisLife")] Reception reception)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reception);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAnalyze"] = new SelectList(_context.Analyze, "IdAnalyzes", "IdAnalyzes", reception.IdAnalyze);
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", reception.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", reception.IdDoctor);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService", reception.IdService);
            ViewData["IdStydy"] = new SelectList(_context.Stydy, "IdStydy", "IdStydy", reception.IdStydy);
            return View(reception);
        }

        // GET: Receptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reception == null)
            {
                return NotFound();
            }

            var reception = await _context.Reception.FindAsync(id);
            if (reception == null)
            {
                return NotFound();
            }
            ViewData["IdAnalyze"] = new SelectList(_context.Analyze, "IdAnalyzes", "IdAnalyzes", reception.IdAnalyze);
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", reception.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", reception.IdDoctor);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService", reception.IdService);
            ViewData["IdStydy"] = new SelectList(_context.Stydy, "IdStydy", "IdStydy", reception.IdStydy);
            return View(reception);
        }

        // POST: Receptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReception,Date,IdDepartament,IdDoctor,IdService,Diagnosis,Complaints,IdAnalyze,IdStydy,TreatmentPlan,AnamnesisDisease,AnamnesisLife")] Reception reception)
        {
            if (id != reception.IdReception)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reception);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceptionExists(reception.IdReception))
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
            ViewData["IdAnalyze"] = new SelectList(_context.Analyze, "IdAnalyzes", "IdAnalyzes", reception.IdAnalyze);
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", reception.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", reception.IdDoctor);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService", reception.IdService);
            ViewData["IdStydy"] = new SelectList(_context.Stydy, "IdStydy", "IdStydy", reception.IdStydy);
            return View(reception);
        }

        // GET: Receptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reception == null)
            {
                return NotFound();
            }

            var reception = await _context.Reception
                .Include(r => r.Analyze)
                .Include(r => r.Departament)
                .Include(r => r.Doctor)
                .Include(r => r.Service)
                .Include(r => r.Stydy)
                .FirstOrDefaultAsync(m => m.IdReception == id);
            if (reception == null)
            {
                return NotFound();
            }

            return View(reception);
        }

        // POST: Receptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reception == null)
            {
                return Problem("Entity set 'PatientCardContext.Reception'  is null.");
            }
            var reception = await _context.Reception.FindAsync(id);
            if (reception != null)
            {
                _context.Reception.Remove(reception);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceptionExists(int id)
        {
          return (_context.Reception?.Any(e => e.IdReception == id)).GetValueOrDefault();
        }
    }
}
