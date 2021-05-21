using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourTravel.Models;

namespace TourTravel.Repository
{
    public interface iMaster_Repository
    {
        List<MasterData_DTO> GetMasterData();

        List<MasterData_DTO> GetMasterData(string ActionBy);

        List<MasterData_DTO> GetWeekRange(string ActionBy, int UID);

        List<SelectListItem> GetMasterDataItems(string ActionBy, string FilterBy, string FilterBy2);

        List<MasterData_DTO> GetMasterData(string ActionBy, string FilterBy, string FilterBy2);
    }
}