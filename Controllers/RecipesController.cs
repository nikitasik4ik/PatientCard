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
    public class RecipesController : Controller
    {
        private readonly PatientCardContext _context;

        public RecipesController(PatientCardContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            var patientCardContext = _context.Recipe.Include(r => r.Doctor).Include(r => r.SignatureDoctor).Include(r => r.User);
            return View(await patientCardContext.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recipe == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .Include(r => r.Doctor)
                .Include(r => r.SignatureDoctor)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.IdRecipe == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor");
            ViewData["IdSignatureDoctor"] = new SelectList(_context.Set<SignatureDoctor>(), "IdSignatureDoctor", "IdSignatureDoctor");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRecipe,CodeRecipe,DateRecipe,UserId,IdDoctor,RecipeName,IdSignatureDoctor")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", recipe.IdDoctor);
            ViewData["IdSignatureDoctor"] = new SelectList(_context.Set<SignatureDoctor>(), "IdSignatureDoctor", "IdSignatureDoctor", recipe.IdSignatureDoctor);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", recipe.UserId);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recipe == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", recipe.IdDoctor);
            ViewData["IdSignatureDoctor"] = new SelectList(_context.Set<SignatureDoctor>(), "IdSignatureDoctor", "IdSignatureDoctor", recipe.IdSignatureDoctor);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", recipe.UserId);
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRecipe,CodeRecipe,DateRecipe,UserId,IdDoctor,RecipeName,IdSignatureDoctor")] Recipe recipe)
        {
            if (id != recipe.IdRecipe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.IdRecipe))
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
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", recipe.IdDoctor);
            ViewData["IdSignatureDoctor"] = new SelectList(_context.Set<SignatureDoctor>(), "IdSignatureDoctor", "IdSignatureDoctor", recipe.IdSignatureDoctor);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", recipe.UserId);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recipe == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .Include(r => r.Doctor)
                .Include(r => r.SignatureDoctor)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.IdRecipe == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recipe == null)
            {
                return Problem("Entity set 'PatientCardContext.Recipe'  is null.");
            }
            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipe.Remove(recipe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
          return (_context.Recipe?.Any(e => e.IdRecipe == id)).GetValueOrDefault();
        }
    }
}
