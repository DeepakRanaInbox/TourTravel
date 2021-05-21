using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TourTravel.Models;

namespace UtilizationTrackerApp.Models.Data
{
    public class TravelHistory_Model:TravelAmount_Model
    {
 

        public string vSRNO { get; set; }
        public string Todaydate { get; set; }
        [Required(ErrorMessage ="User Name is required")]
        public string vUserName { get; set; }
        public string vPartyGSTIN { get; set; }

        [Required(ErrorMessage = "Driver Name is required")]
        public string vDriverName { get; set; }

        //[DataType(dataType:DataType.PhoneNumber,ErrorMessage ="Please Enter Phone Number")] 
        public string vUserPhoneNo { get; set; }

        //[DataType(dataType: DataType.PhoneNumber, ErrorMessage = "Please Enter Phone Number")]
        public string vDriverPhoneNo { get; set; }
        public string vAddress { get; set; }

        [Required(ErrorMessage = "From /To Place is required")]
        public string vFromToPlace { get; set; }

        [Required(ErrorMessage = "Vehicle is required")]
        public string vVehicleNo { get; set; }


        [Required(ErrorMessage = "Vehicle Type is required")]
        public string iVehicleType { get; set; }

        public List<SelectListItem> VehicleType { get; set; }

        [Required(ErrorMessage = "Starting Date is required")]
        public string dStartingDate { get; set; }


        public string dClosingDate { get; set; }

        [DataType(dataType:DataType.Duration, ErrorMessage = "Please enter valid integer Number")]
        public int iHoliday { get; set; }

        [DataType(dataType: DataType.Duration, ErrorMessage = "Please enter valid integer Number")]
        [Required(ErrorMessage = "Total Days is required")]
        public int iTotalDays { get; set; }

        [DataType(dataType: DataType.Duration, ErrorMessage = "Please enter valid integer Number")]
        public int iStartingKM { get; set; }

        [DataType(dataType: DataType.Duration, ErrorMessage = "Please enter valid integer Number")]
        public int iClosingKM { get; set; }


        [DataType(dataType: DataType.Duration, ErrorMessage = "Please enter valid integer Number")]
        public int iTotalKM { get; set; }

        public string Taxitemlist { get; set; }

        public List<TravelTax_Model> TaxList { get; set; }

        public List<TravelHistory_Model> TravelHistory { get; set; }

    }
}