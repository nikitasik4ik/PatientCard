﻿using System;
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
    public class AnalyzesController : Controller
    {
        private readonly PatientCardContext _context;

        public AnalyzesController(PatientCardContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            if (userRole == "Admin")
            {
                var analyzes = await _context.Analyze
                    .Include(a => a.Departament)
                    .Include(a => a.Doctor)
                    .Include(a => a.Organization)
                    .Include(a => a.Service)
                    .Include(a => a.User)
                    .ToListAsync();

                return View(analyzes);
            }
            else
            {
                var analyzes = await _context.Analyze
                    .Where(a => a.UserId == userId)
                    .Include(a => a.Departament)
                    .Include(a => a.Doctor)
                    .Include(a => a.Organization)
                    .Include(a => a.Service)
                    .Include(a => a.User)
                    .ToListAsync();

                return View(analyzes);
            }
        }

        // GET: Analyzes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Analyze == null)
            {
                return NotFound();
            }

            var analyze = await _context.Analyze
                .Include(a => a.Departament)
                .Include(a => a.Doctor)
                .Include(a => a.Organization)
                .Include(a => a.Service)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.IdAnalyzes == id);
            if (analyze == null)
            {
                return NotFound();
            }

            return View(analyze);
        }

        // GET: Analyzes/Create
        public IActionResult Create()
        {
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "NameDepartament");
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "FullNameDoctor");
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "Name");
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "NameService");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View();
        }

        // POST: Analyzes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAnalyzes,IdDepartament,IdOrganization,IdService,DateAnalyzes,IdDoctor,UserId")] Analyze analyze)
        {
            if (ModelState.IsValid)
            {
                _context.Add(analyze);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", analyze.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", analyze.IdDoctor);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", analyze.IdOrganization);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService", analyze.IdService);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", analyze.UserId);
            return View(analyze);
        }

        // GET: Analyzes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Analyze == null)
            {
                return NotFound();
            }

            var analyze = await _context.Analyze.FindAsync(id);
            if (analyze == null)
            {
                return NotFound();
            }
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "NameDepartament", analyze.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "FullNameDoctor", analyze.IdDoctor);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "Name", analyze.IdOrganization);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "NameService", analyze.IdService);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", analyze.UserId);
            return View(analyze);
        }

        // POST: Analyzes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnalyzes,IdDepartament,IdOrganization,IdService,DateAnalyzes,IdDoctor,UserId")] Analyze analyze)
        {
            if (id != analyze.IdAnalyzes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analyze);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalyzeExists(analyze.IdAnalyzes))
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
            ViewData["IdDepartament"] = new SelectList(_context.Departament, "IdDepartament", "IdDepartament", analyze.IdDepartament);
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", analyze.IdDoctor);
            ViewData["IdOrganization"] = new SelectList(_context.Organization, "IdOrganization", "IdOrganization", analyze.IdOrganization);
            ViewData["IdService"] = new SelectList(_context.Service, "IdService", "IdService", analyze.IdService);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", analyze.UserId);
            return View(analyze);
        }

        // GET: Analyzes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Analyze == null)
            {
                return NotFound();
            }

            var analyze = await _context.Analyze
                .Include(a => a.Departament)
                .Include(a => a.Doctor)
                .Include(a => a.Organization)
                .Include(a => a.Service)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.IdAnalyzes == id);
            if (analyze == null)
            {
                return NotFound();
            }

            return View(analyze);
        }

        // POST: Analyzes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Analyze == null)
            {
                return Problem("Entity set 'PatientCardContext.Analyze'  is null.");
            }
            var analyze = await _context.Analyze.FindAsync(id);
            if (analyze != null)
            {
                _context.Analyze.Remove(analyze);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalyzeExists(int id)
        {
          return (_context.Analyze?.Any(e => e.IdAnalyzes == id)).GetValueOrDefault();
        }
    }
}
