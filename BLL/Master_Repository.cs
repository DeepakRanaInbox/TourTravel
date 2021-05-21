using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourTravel.Models;
using TourTravel.Repository;
using UtilizationTrackerApp.Models.Data;
using UtilizationTrackerApp.Utility;

namespace TourTravel.BLL
{
    public class Master_Repository : iMaster_Repository
    {
        public List<MasterData_DTO> GetMasterData()
        {
            List<MasterData_DTO> MyModelList = new List<MasterData_DTO>();

            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {
                    MyModelList = con.Query<MasterData_DTO>("ProcGetMasterData", null, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception Exc)
            {
                Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "Master_Repository", vAction = "GetMasterData", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyModelList;
        }


        public List<MasterData_DTO> GetMasterData(string ActionBy)
        {
            List<MasterData_DTO> MyModelList = new List<MasterData_DTO>();

            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {
                    DynamicParameters MyDynamicParameters = new DynamicParameters();

                    MyDynamicParameters.Add("@Action", ActionBy);

                    MyModelList = con.Query<MasterData_DTO>("ProcGetMasterData", MyDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception Exc)
            {
                Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "Master_Repository", vAction = "GetMasterData", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyModelList;
        }

        public List<MasterData_DTO> GetWeekRange(string ActionBy, int UID)
        {
            List<MasterData_DTO> MyModelList = new List<MasterData_DTO>();

            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {
                    DynamicParameters MyDynamicParameters = new DynamicParameters();

                    MyDynamicParameters.Add("@iWeekIDF", ActionBy);
                    MyDynamicParameters.Add("@iUserID", UID);

                    MyModelList = con.Query<MasterData_DTO>("ProcGetWeeksRangeForFilter", MyDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception Exc)
            {
                Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "Master_Repository", vAction = "GetMasterData", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyModelList;
        }


        public List<SelectListItem> GetMasterDataItems(string ActionBy, string FilterBy, string FilterBy2 = "0")
        {
            List<SelectListItem> MyModelList = new List<SelectListItem>();

            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {
                    DynamicParameters MyDynamicParameters = new DynamicParameters();

                    MyDynamicParameters.Add("@Action", ActionBy);
                    MyDynamicParameters.Add("@FilterBy", FilterBy);
                    MyDynamicParameters.Add("@FilterBy2", FilterBy2);
                    MyModelList = con.Query<SelectListItem>("ProcGetMasterData", MyDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception Exc)
            {
                Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "Master_Repository", vAction = "GetMasterData", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyModelList;
        }

        public List<MasterData_DTO> GetMasterData(string ActionBy, string FilterBy, string FilterBy2 = "0")
        {
            List<MasterData_DTO> MyModelList = new List<MasterData_DTO>();

            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {
                    DynamicParameters MyDynamicParameters = new DynamicParameters();

                    MyDynamicParameters.Add("@Action", ActionBy);
                    MyDynamicParameters.Add("@FilterBy", FilterBy);
                    MyDynamicParameters.Add("@FilterBy2", FilterBy2);
                    MyModelList = con.Query<MasterData_DTO>("ProcGetMasterData", MyDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception Exc)
            {
                Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "Master_Repository", vAction = "GetMasterData", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyModelList;
        }
    }
}