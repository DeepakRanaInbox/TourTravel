using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourTravel.Models
{
    public class Login_DTO
    {
        public int ID { set; get; }
        public string vName { set; get; }
        public string vRole { set; get; }
        public string iRoleID { set; get; }
        public string vLoginID { set; get; }
      
        public string Result { set; get; }
    }
}