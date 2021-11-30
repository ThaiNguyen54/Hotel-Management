using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_Project.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
