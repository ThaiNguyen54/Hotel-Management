using Hotel_Management_Project.Models;
using Hotel_Management_Project.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_Project.Controllers
{
    public class LoginController : Controller
    {
        public bool Valid { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(AccountModel account)
        {
            bool IsValid;
            SecurityService security = new SecurityService();
            IsValid = security.IsValid(account);
            Valid = IsValid;
            if (IsValid == true)
            {
                return View(account);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}
