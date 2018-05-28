using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace askAnything.Models
{
    public class AdminModel
    {
        public int Admin_id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DataType(DataType.Text)]
        public string First_Name { get; set; }

        [DataType(DataType.Text)]
        public string Last_Name { get; set; }
    }
}