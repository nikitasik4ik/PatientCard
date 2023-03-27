using Microsoft.AspNetCore.Mvc;
using PatientCard.Data;
using PatientCard.Models;

namespace PatientCard.Controllers
{
    public class HealthDiaryController : Controller
    {
    private readonly PatientCardContext _context;
        public HealthDiaryController(PatientCardContext context)
        {
            _context = context;
        }
        // GET: HealthDiary
        public ActionResult Index()
        {
            var tables = new HealthDiary
            {
                Temperature = _context.Temperature.ToList(),
                Anthropometry = _context.Anthropometry.ToList(),
                Oxygen = _context.Oxygen.ToList(),
                Glucose = _context.Glucose.ToList(),
                Pressure = _context.Pressure.ToList()
            };
            return View(tables);
        }
    }
}


