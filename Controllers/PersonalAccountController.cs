using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientCard.Data;
using PatientCard.Models;

namespace PatientCard.Controllers
{
    public class PersonalAccountController : Controller
    {
        private readonly PatientCardContext _context;

        public PersonalAccountController(PatientCardContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var disabilitySheet = _context.DisabilitySheet.Include(d => d.User).Include(d => d.Doctor).FirstOrDefault();
            var analyze = _context.Analyze.Include(a => a.Doctor).Include(a => a.Service).FirstOrDefault();

            var viewModel = new PersonalAccount
            {
                DisabilitySheet = disabilitySheet,
                Analyze = analyze
            };

            return View(viewModel);
        }

    }
}
