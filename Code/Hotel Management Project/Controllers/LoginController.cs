using Hotel_Management_Project.Common;
using Hotel_Management_Project.Models;
using Hotel_Management_Project.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management_Project.Controllers
{
   [Route("login-page")]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            var lg = new AccountDao();
            if (lg.isLoginSuccess(loginModel))
            {
                UserCurrent.userName = loginModel.Username;
                UserCurrent.isActive = true;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                UserCurrent.userName = "";
                UserCurrent.isActive = true;
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai!");
            }
            return RedirectToAction("Index", "Login");
        }

    }
}
