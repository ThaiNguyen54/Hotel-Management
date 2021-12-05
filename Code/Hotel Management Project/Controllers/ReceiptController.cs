using Hotel_Management_Project.Models;
using Hotel_Management_Project.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_Project.Controllers
{
    public class ReceiptController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProcessBook(ReceiptModel receipt)
        {
            ReceiptDAO receiptDAO = new ReceiptDAO();
            receiptDAO.InsertReceipt(receipt);
            return View();
        }
    }
}
