using System;

namespace Hotel_Management_Project.Models
{
    public class ReceiptModel
    {
        public int ReceiptId { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int TotalCost { get; set; }
        public DateTime date { get; set; }
    }
}
