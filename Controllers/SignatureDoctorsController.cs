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
    public class SignatureDoctorsController : Controller
    {
        private readonly PatientCardContext _context;

        public SignatureDoctorsController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: SignatureDoctors
        public async Task<IActionResult> Index()
        {
            var patientCardContext = _context.SignatureDoctor.Include(s => s.Doctor);
            return View(await patientCardContext.ToListAsync());
        }

        // GET: SignatureDoctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SignatureDoctor == null)
            {
                return NotFound();
            }

            var signatureDoctor = await _context.SignatureDoctor
                .Include(s => s.Doctor)
                .FirstOrDefaultAsync(m => m.IdSignatureDoctor == id);
            if (signatureDoctor == null)
            {
                return NotFound();
            }

            return View(signatureDoctor);
        }

        // GET: SignatureDoctors/Create
        public IActionResult Create()
        {
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor");
            return View();
        }

        // POST: SignatureDoctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSignatureDoctor,Information,Certificate,IdDoctor,ValidWith,ValidUntil")] SignatureDoctor signatureDoctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signatureDoctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", signatureDoctor.IdDoctor);
            return View(signatureDoctor);
        }

        // GET: SignatureDoctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SignatureDoctor == null)
            {
                return NotFound();
            }

            var signatureDoctor = await _context.SignatureDoctor.FindAsync(id);
            if (signatureDoctor == null)
            {
                return NotFound();
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", signatureDoctor.IdDoctor);
            return View(signatureDoctor);
        }

        // POST: SignatureDoctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSignatureDoctor,Information,Certificate,IdDoctor,ValidWith,ValidUntil")] SignatureDoctor signatureDoctor)
        {
            if (id != signatureDoctor.IdSignatureDoctor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signatureDoctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignatureDoctorExists(signatureDoctor.IdSignatureDoctor))
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
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", signatureDoctor.IdDoctor);
            return View(signatureDoctor);
        }

        // GET: SignatureDoctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SignatureDoctor == null)
            {
                return NotFound();
            }

            var signatureDoctor = await _context.SignatureDoctor
                .Include(s => s.Doctor)
                .FirstOrDefaultAsync(m => m.IdSignatureDoctor == id);
            if (signatureDoctor == null)
            {
                return NotFound();
            }

            return View(signatureDoctor);
        }

        // POST: SignatureDoctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SignatureDoctor == null)
            {
                return Problem("Entity set 'PatientCardContext.SignatureDoctor'  is null.");
            }
            var signatureDoctor = await _context.SignatureDoctor.FindAsync(id);
            if (signatureDoctor != null)
            {
                _context.SignatureDoctor.Remove(signatureDoctor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignatureDoctorExists(int id)
        {
          return (_context.SignatureDoctor?.Any(e => e.IdSignatureDoctor == id)).GetValueOrDefault();
        }
    }
}
