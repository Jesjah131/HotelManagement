using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class UserLoginModel
    {
        [Display(Name="Username!")]
        [Required(ErrorMessage="You must write your username!")]
        public string Username { get; set; }

        [Display(Name = "Password!")]
        [Required(ErrorMessage = "You forgot your password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}