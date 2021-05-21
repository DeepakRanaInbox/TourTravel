using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourTravel.Models;
using UtilizationTrackerApp.Models.Data;

namespace TourTravel.Repository
{
    public interface iTravel_Repository
    {
     
        List<TravelHistory_Model> GetEntity_List(string Action, TravelHistory_Model MyModel);

        bool ManageEntity(TravelHistory_Model MyModel);

        List<TravelTax_Model> GetTravelTax_List(int TravelID);
    }
}