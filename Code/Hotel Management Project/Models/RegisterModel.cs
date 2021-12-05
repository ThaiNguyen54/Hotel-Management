using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management_Project.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Please enter your Username")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is not correct")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        internal void InsertCustomer(RegisterModel register)
        {
            throw new NotImplementedException();
        }

        [Required(ErrorMessage = "Please enter your FullName")]
        [Display (Name ="Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your Address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Phone Number")]
        [Display(Name = "Phone Number")]
        public int Phonenumber { get; set; }


    }
}
