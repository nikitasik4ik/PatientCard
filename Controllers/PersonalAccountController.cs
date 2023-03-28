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
            var personalAccount = new PersonalAccount();

            var analyze = await _context.Analyze
                .Where(t => t.UserId == userId)
                .Include(t => t.User)
                .Include(t => t.Doctor)
                .Include(t => t.Service)
                .Include(t => t.Departament)
                .Include(t => t.Organization)
                .ToListAsync();


            personalAccount.Analyze = analyze;

            var disabilitySheets = await _context.DisabilitySheet
                .Where(d => d.UserId == userId)
                .Include(d => d.User)
                .Include(d => d.Doctor)
                .Include(d => d.Departament)
                .Include(d => d.Organization)
                .ToListAsync();

            personalAccount.DisabilitySheet = disabilitySheets;

            var medicalCars = await _context.MedicalCar
            .Where(m => m.UserId == userId)
            .Include(m => m.User)
            .Include(m => m.Doctor)
            .ToListAsync();

            personalAccount.MedicalCar = medicalCars ;

            var operations = await _context.Operation
                .Where(t => t.UserId == userId)
                .Include(t => t.User)
                .Include(t => t.Doctor)
                .Include(t => t.Service)
                .Include(t => t.Departament)
                .Include(t => t.Organization)
                .ToListAsync();


            personalAccount.Operation = operations ;

            var polyclinics = await _context.Polyclinic
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .Include(p => p.Doctor)
                .Include(p => p.Financing)
                .Include(p => p.Departament)
                .Include(p => p.Organization)
                .ToListAsync();
            personalAccount.Polyclinic = polyclinics;

            var studies = await _context.Stydy
                .Where(t => t.UserId == userId)
                .Include(t => t.User)
                .Include(t => t.Doctor)
                .Include(t => t.Departament)
                .Include(t => t.Organization)
                .ToListAsync();

            personalAccount.Stydy = studies ;

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
