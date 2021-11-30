using Hotel_Management_Project.Models;
using Hotel_Management_Project.Service;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Hotel_Management_Project.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            CustomerDAO customers = new CustomerDAO();
            return View(customers.GetAllCustomer());
        }

        public IActionResult ShowInsertForm()
        {
            return View();
        }

        public IActionResult ProcessInsert(CustomerModel customer)
        {
            CustomerDAO customers = new CustomerDAO();
            customers.InsertCustomer(customer);
            return View();
        }

        public IActionResult Edit(int customerID)
        {
            var url = HttpContext.Request.GetEncodedUrl();
            string last = url.Split('/').Last();
            CustomerDAO customer = new CustomerDAO();
            CustomerModel foundCustomer = null;
            try
            {
                foundCustomer = customer.GetCustomerByID(Convert.ToInt32(last));
            }
            catch (Exception ex)
            {

            }
            return View("ShowEditForm", foundCustomer);
        }

        public IActionResult ProcessEdit(CustomerModel customer)
        {
            CustomerDAO customers = new CustomerDAO();
            customers.UpdateCustomer(customer);
            return View();
        }

        public IActionResult Delete(int CustomerID)
        {
            var url = HttpContext.Request.GetEncodedUrl();
            string last = url.Split('/').Last();
            CustomerDAO customers = new CustomerDAO();
            CustomerModel customer = null;
            try
            {
                customer = customers.GetCustomerByID(Convert.ToInt32(last));
                customers.DeleteCustomer(customer);
            }
            catch (Exception ex)
            {

            }

            return View();
        }
    }
}
