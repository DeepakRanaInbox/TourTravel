using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourTravel.Models
{
    public class Error_DTO
    {
        public string vApplication { set; get; }
        public string vError_Message { set; get; }
        public string vError_Line { set; get; }
        public string vController { set; get; }
        public string vAction { set; get; }
        public string vInput_Values { set; get; }
        public string vAction_Type { set; get; }
        public string vRemarks { set; get; }
    }
}