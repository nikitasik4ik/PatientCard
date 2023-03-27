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
    public class OperationsController : Controller
    {
        private readonly PatientCardContext _context;

        public OperationsController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: Operations
        public async Task<IActionResult> Index()
        {
            var patientCardContext = _context.Operation.Include(o => o.Departament).Include(o => o.Doctor).Include(o => o.Financing).Include(o => o.Organization).Include(o => o.Service).Include(o => o.User);
            return View(await patientCardContext.ToListAsync());
        }

        // GET: Operations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Operation == null)
            {
                return NotFound();
            }

            var operation = await _context.Operation
                .Include(o => o.Departament)
                .Include(o => o.Doctor)
                .Include(o => o.Financing)
                .Include(o => o.Organization)
                .Include(o => o.Service)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.IdOperation == id);
            if (operation == null)
            {
                return NotFound();
            }

            return View(operation);
        }

        // GET: Operations/Create
        public IActionResult Create()
        {
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament");
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor");
            ViewData["IdFinancing"] = new SelectList(_context.Financing, "IdFinancing", "IdFinancing");
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization");
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Operations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOperation,UserId,DateOperation,NameOperation,IdDepartament,IdOrganization,DiagnosisOperation,IdService,DurationOperation,ProtocolOperation,IdFinancing,IdDoctor")] Operation operation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", operation.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", operation.IdDoctor);
            ViewData["IdFinancing"] = new SelectList(_context.Financing, "IdFinancing", "IdFinancing", operation.IdFinancing);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", operation.IdOrganization);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService", operation.IdService);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", operation.UserId);
            return View(operation);
        }

        // GET: Operations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Operation == null)
            {
                return NotFound();
            }

            var operation = await _context.Operation.FindAsync(id);
            if (operation == null)
            {
                return NotFound();
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", operation.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", operation.IdDoctor);
            ViewData["IdFinancing"] = new SelectList(_context.Financing, "IdFinancing", "IdFinancing", operation.IdFinancing);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", operation.IdOrganization);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService", operation.IdService);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", operation.UserId);
            return View(operation);
        }

        // POST: Operations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOperation,UserId,DateOperation,NameOperation,IdDepartament,IdOrganization,DiagnosisOperation,IdService,DurationOperation,ProtocolOperation,IdFinancing,IdDoctor")] Operation operation)
        {
            if (id != operation.IdOperation)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperationExists(operation.IdOperation))
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
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", operation.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", operation.IdDoctor);
            ViewData["IdFinancing"] = new SelectList(_context.Financing, "IdFinancing", "IdFinancing", operation.IdFinancing);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", operation.IdOrganization);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService", operation.IdService);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", operation.UserId);
            return View(operation);
        }

        // GET: Operations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Operation == null)
            {
                return NotFound();
            }

            var operation = await _context.Operation
                .Include(o => o.Departament)
                .Include(o => o.Doctor)
                .Include(o => o.Financing)
                .Include(o => o.Organization)
                .Include(o => o.Service)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.IdOperation == id);
            if (operation == null)
            {
                return NotFound();
            }

            return View(operation);
        }

        // POST: Operations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Operation == null)
            {
                return Problem("Entity set 'PatientCardContext.Operation'  is null.");
            }
            var operation = await _context.Operation.FindAsync(id);
            if (operation != null)
            {
                _context.Operation.Remove(operation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperationExists(int id)
        {
          return (_context.Operation?.Any(e => e.IdOperation == id)).GetValueOrDefault();
        }
    }
}
