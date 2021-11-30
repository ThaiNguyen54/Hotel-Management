using Microsoft.OData.Edm;
using System;

namespace Hotel_Management_Project.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime CustomerBirthDate { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
    }
}
