using System;
using System.ComponentModel;

namespace Hotel_Management_Project.Models
{
    public class ReceptionistModel
    {
        [DisplayName ("ID")]
        public int ReceptionistId { get; set; }
        [DisplayName("Name")]
        public string ReceptionistName { get; set; }
        [DisplayName("Birth Day")]
        public DateTime ReceptionistBirthDay { get; set;}
        [DisplayName("Phone")]
        public string ReceptionistPhone { get; set;}
        [DisplayName("Address")]
        public string ReceptionistAddress { get; set;}
    }
}
