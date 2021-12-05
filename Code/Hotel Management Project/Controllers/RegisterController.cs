using Hotel_Management_Project.Models;
using Hotel_Management_Project.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management_Project.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register(RegisterModel register)
        {
            CustomerDAO regis = new CustomerDAO();
            register.InsertCustomer(register);
            return View();
        }
    }
}
