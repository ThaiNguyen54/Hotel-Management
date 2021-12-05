using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management_Project.Models
{
    public class LoginModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public object Email { get; internal set; }
    }
}
//code hài vậy cha nội

