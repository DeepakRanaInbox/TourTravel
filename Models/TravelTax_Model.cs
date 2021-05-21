using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilizationTrackerApp.Models.Data
{
    public class TravelTax_Model
    {

        public string iTravelID { get; set; }

        public string iTaxID { get; set; }
        public string  vTax  { get; set; }
        public string mTax { get; set; }

        public string mTaxAmount { get; set; }

        public List<TravelTax_Model> TravelTaxList { get; set; }
    }
}