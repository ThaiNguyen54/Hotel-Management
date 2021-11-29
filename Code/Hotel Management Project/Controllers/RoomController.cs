using Hotel_Management_Project.Models;
using Hotel_Management_Project.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;

namespace Hotel_Management_Project.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            RoomDAO rooms = new RoomDAO();

            return View(rooms.GetAllRoom());
        }

        public IActionResult ShowDetails(int RoomID)
        {
            var url = HttpContext.Request.GetEncodedUrl();
            string last = url.Split('/').Last();
            RoomDAO room = new RoomDAO();
            RoomModel foundRoom = null;
            try
            {
                 foundRoom = room.GetRoomByID(Convert.ToInt32(last));
            }
            catch (Exception ex)
            {

            }
            return View(foundRoom);
        }
    }
}
