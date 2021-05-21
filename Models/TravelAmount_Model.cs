using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TourTravel.Models;
//using UtilizationTrackerApp.Models.DTO;

namespace UtilizationTrackerApp.Models.Data
{
    public class TravelAmount_Model
    {
        
        public int iTravelID { get; set; }

        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid price/charges !")]
        public decimal mPerKMChangres { get; set; }

        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid price/charges !")]
        public decimal mPerDayChangres { get; set; }

        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid price/charges !")]
        public decimal mNightChangres { get; set; }

        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid price/charges !")]
        public decimal mTollTaxAndParking { get; set; }
        public string mTotalAmountBeforeTax { get; set; }
        public string mTotalAmount  { get; set; }

        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid price/charges !")]
        public decimal mDiscountAmount { get; set; }
        public string vDiscountRemarks { get; set; }
        public string mTotalTaxAmount { get; set; }

        public List<MasterData_DTO> TravelTaxList { get; set; }

    }
}