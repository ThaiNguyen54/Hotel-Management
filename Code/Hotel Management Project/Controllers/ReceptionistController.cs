using Hotel_Management_Project.Models;
using Hotel_Management_Project.Service;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Hotel_Management_Project.Controllers
{
    public class ReceptionistController : Controller
    {
        public IActionResult Index()
        {
            ReceptionistDAO receptionistDAO = new ReceptionistDAO();
            return View(receptionistDAO.GetAllReceptionist());
        }

        public IActionResult Edit(int ReceptionistID)
        {
            var url = HttpContext.Request.GetEncodedUrl();
            string last = url.Split('/').Last();
            ReceptionistDAO receptionist = new ReceptionistDAO();
            ReceptionistModel foundReceptionist = null;
            try
            {
                foundReceptionist = receptionist.GetReceptionistByID(Convert.ToInt32(last));
            }
            catch (Exception ex)
            {

            }
            return View("ShowEditForm", foundReceptionist);
        }

        public IActionResult ProcessEdit(ReceptionistModel receptionist)
        {
            ReceptionistDAO receptionists = new ReceptionistDAO();
            receptionists.UpdateReceptionist(receptionist);
            return View();
        }

        public IActionResult InsertReceptionistForm()
        {
            return View();
            
        }

        public IActionResult ProcessInsert(ReceptionistModel receptionist)
        {
            ReceptionistDAO receptionists = new ReceptionistDAO();
            receptionists.InsertReceptionist(receptionist);
            return View();
        }

        public IActionResult Delete(int ReceptionistID)
        {
            var url = HttpContext.Request.GetEncodedUrl();
            string last = url.Split('/').Last();
            ReceptionistDAO receptionists = new ReceptionistDAO();
            ReceptionistModel receptionist = null;
            try
            {
                receptionist = receptionists.GetReceptionistByID(Convert.ToInt32(last));
                receptionists.DeleteReceptionist(receptionist);
            }
            catch (Exception ex)
            {

            }

            return View();
        }
    }
}
