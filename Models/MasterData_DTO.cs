using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourTravel.Models
{
    public class MasterData_DTO
    {
        public string ID { set; get; }
        public string vName { set; get; }
        public int iParentID { set; get; }
        public string vParent { set; get; }
        public string vType { set; get; }
        public int iCount { set; get; }
        public string vStatus { set; get; }
        public string mTax { set; get; }
        public List<MasterData_DTO> MasterList { set; get; }
        

    }

    public class DropDownModel
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}