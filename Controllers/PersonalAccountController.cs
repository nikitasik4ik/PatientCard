using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientCard.Data;
using PatientCard.Models;
using System.Security.Claims;

namespace PatientCard.Controllers
{
    public class PersonalAccountController : Controller
    {
        private readonly PatientCardContext _context;

        public PersonalAccountController(PatientCardContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var analyze = await _context.Analyze
                .Where(t => t.UserId == userId)
                .Include(t => t.User)
                .Include(t => t.Doctor)
                .Include(t => t.Service)
                .FirstOrDefaultAsync();


            var personalAccount = new PersonalAccount { Analyze = analyze };


            var disabilitySheet = await _context.DisabilitySheet
                .Where(d => d.UserId == userId)
                .Include(d => d.User)
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync();

            personalAccount.DisabilitySheet = disabilitySheet;

            // Load Anthropometry records
            var anthropometries = await _context.Anthropometry
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
            personalAccount.Anthropometry = anthropometries;

            // Load Temperature records
            var temperatures = await _context.Temperature
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.Date)
                .ToListAsync();
            personalAccount.Temperature = temperatures;

            // Load Pressure records
            var pressures = await _context.Pressure
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.Date)
                .ToListAsync();
            personalAccount.Pressure = pressures;

            // Load Glucose records
            var glucoses = await _context.Glucose
                .Where(g => g.UserId == userId)
                .OrderByDescending(g => g.Date)
                .ToListAsync();
            personalAccount.Glucose = glucoses;

            // Load Oxygen records
            var oxygens = await _context.Oxygen
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.Date)
                .ToListAsync();
            personalAccount.Oxygen = oxygens;

            return View(personalAccount);
        }

    }
}
