using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourTravel.Models
{
    public class Login_Model
    {
        public int ID { set; get; }

        [Required(ErrorMessage = "Login id is required!")]
        public string vLoginID { set; get; }

        [Required(ErrorMessage = "Password is required!")]
        public string vPassword { set; get; }

        public string JWTToken { set; get; }
        public string DataKey { set; get; }
         
        public string __RequestVerificationToken { set; get; }
    }
}