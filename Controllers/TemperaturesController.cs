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
    public class TemperaturesController : Controller
    {
        private readonly PatientCardContext _context;

        public TemperaturesController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: Temperatures
        public async Task<IActionResult> Index()
        {
              return _context.Temperature != null ? 
                          View(await _context.Temperature.ToListAsync()) :
                          Problem("Entity set 'PatientCardContext.Temperature'  is null.");
        }

        // GET: Temperatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Temperature == null)
            {
                return NotFound();
            }

            var temperature = await _context.Temperature
                .FirstOrDefaultAsync(m => m.TemperatureId == id);
            if (temperature == null)
            {
                return NotFound();
            }

            return View(temperature);
        }

        // GET: Temperatures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Temperatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TemperatureId,Value,Date,UserId")] Temperature temperature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temperature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(temperature);
        }

        // GET: Temperatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Temperature == null)
            {
                return NotFound();
            }

            var temperature = await _context.Temperature.FindAsync(id);
            if (temperature == null)
            {
                return NotFound();
            }
            return View(temperature);
        }

        // POST: Temperatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TemperatureId,Value,Date,UserId")] Temperature temperature)
        {
            if (id != temperature.TemperatureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temperature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemperatureExists(temperature.TemperatureId))
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
            return View(temperature);
        }

        // GET: Temperatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Temperature == null)
            {
                return NotFound();
            }

            var temperature = await _context.Temperature
                .FirstOrDefaultAsync(m => m.TemperatureId == id);
            if (temperature == null)
            {
                return NotFound();
            }

            return View(temperature);
        }

        // POST: Temperatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Temperature == null)
            {
                return Problem("Entity set 'PatientCardContext.Temperature'  is null.");
            }
            var temperature = await _context.Temperature.FindAsync(id);
            if (temperature != null)
            {
                _context.Temperature.Remove(temperature);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemperatureExists(int id)
        {
          return (_context.Temperature?.Any(e => e.TemperatureId == id)).GetValueOrDefault();
        }
    }
}
