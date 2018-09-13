using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject1.Models
{
    public class admin
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public String LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public String Email { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Compare("Password", ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public String ConfirmPassword { get; set; }
    }
}