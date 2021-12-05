using System.ComponentModel;

namespace Hotel_Management_Project.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        [DisplayName("User name")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        public string PassWord { get; set; }
    }
}
