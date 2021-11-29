using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management_Project.Models
{
    public class RoomModel
    {
        [DisplayName("Room ID")]
        public int RoomID { get; set; }
        [DisplayName("Type")]
        public int RoomTypeID { get; set; }
        [DisplayName("Name")]
        public string RoomName { get; set; }
        [DisplayName("Description")]
        public string RoomDescription { get; set; }
        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public int RoomPrice { get; set; }
    }
}
