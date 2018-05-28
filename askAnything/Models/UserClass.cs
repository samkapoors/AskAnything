using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace askAnything.Models
{
    [Bind(Exclude = "User_id")]    
    public class UserModel
    {
        [ScaffoldColumn(false)]
        public int User_id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]        
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email_id { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(25, MinimumLength = 4)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [StringLength(25, MinimumLength = 4)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password Not Matched")]
        public string Confirm_Password { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3)]
        public string Last_Name { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string Gender { get; set; }
       
    }
}