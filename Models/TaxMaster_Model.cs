using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourTravel.Models
{
    public class TaxMaster_Model
    {
 
        public string  ID { get; set; }
        public string vName { get; set; }
        public string mTax { get; set; }

        public bool bisActive { get; set; }



        public List<MasterData_DTO> TaxMasterList { get; set; }

    }
}