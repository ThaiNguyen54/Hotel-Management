using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Management_Project.Common
{
    [Serializable]
    public class UserSession
    {   public int id { get; set; }
        public string Username { get; set; }
        public List<string> Roles = new List<string>();
       
    }
}