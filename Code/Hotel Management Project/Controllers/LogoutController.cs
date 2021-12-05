using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_Project.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            Hotel_Management_Project.Service.SecurityService.Valid = false;
            return View();
        }
    }
}
