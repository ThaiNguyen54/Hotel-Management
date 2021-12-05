using Hotel_Management_Project.Models;
using Hotel_Management_Project.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_Project.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegisterForm()
        {
            return View();
        }
        public IActionResult RegisterProcess(AccountModel account)
        {
            AccountDAO accountDAO = new AccountDAO();
            accountDAO.InsertAccount(account);
            return View();
        }
    }
}
