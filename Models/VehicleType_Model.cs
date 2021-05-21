using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourTravel.Models
{
    public class VehicleType_Model
    {
        public string ID { get; set; }
        public string vName { get; set; }

        public List<VehicleType_Model> VehicleTypeList { get; set; }

    }
}