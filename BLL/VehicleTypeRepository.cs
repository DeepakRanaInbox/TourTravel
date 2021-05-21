using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TourTravel.Models;
using UtilizationTrackerApp.Models.Data;
using UtilizationTrackerApp.Utility;

namespace TourTravel.BLL
{
    public class VehicleTypeRepository
    {
        public List<VehicleType_Model> GetEntity_List()
        {
            List<VehicleType_Model> MyModelList = new List<VehicleType_Model>();

            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {


                    DynamicParameters MyDynamicParameters = new DynamicParameters();
                    MyDynamicParameters.Add("@ID","");
                    MyDynamicParameters.Add("@vName", "");
                    MyDynamicParameters.Add("@Action", "Get");

                    MyModelList = con.Query<VehicleType_Model>("[dbo].[ProcManageVehicleType]", MyDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception Exc)
            {
                Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "User_Repository", vAction = "GetEntity_List", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyModelList;
        }

        public bool ManageEntity(VehicleType_Model MyModel, string Action)
        {
            bool MyResult = false;

            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {

                    DynamicParameters MyDynamicParameters = new DynamicParameters();

                    MyDynamicParameters.Add("@ID", MyModel.ID);
                    MyDynamicParameters.Add("@vName", MyModel.vName);
                    MyDynamicParameters.Add("@Action", Action);
              
                    MyResult = con.Execute("ProcManageVehicleType", MyDynamicParameters, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                }
            }
            catch (Exception Exc)
            {
                Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "User_Repository", vAction = "GetEntity_List", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyResult;
        }

 
    }
}