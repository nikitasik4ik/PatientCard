using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PatientCard.Models;
using PatientCard.Areas.Identity.Data;

namespace PatientCard.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users;
            return View(users);
        }
    }
}
