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
    public class VehicleType_Repository
    {
        
        public List<MasterData_DTO> GetTaxMaster()
        {
            List<MasterData_DTO> MyModelList = new List<MasterData_DTO>();

            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {

                    DynamicParameters MyDynamicParameters = new DynamicParameters();

                    MyDynamicParameters.Add("@ID", "0");
                    MyDynamicParameters.Add("@Action", "Get");
                    MyDynamicParameters.Add("@vName", "0");
                    MyDynamicParameters.Add("@mTax", "0");


                    MyModelList = con.Query<MasterData_DTO>("[dbo].[ProcManageTax]", MyDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception Exc)
            {
                Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "User_Repository", vAction = "GetEntity_List", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyModelList;
        }
        public bool ManageTaxMaster(MasterData_DTO MyModel, string Action)
        {
            bool MyResult = false;

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {

                    DynamicParameters MyDynamicParameters = new DynamicParameters();

                    MyDynamicParameters.Add("@ID", MyModel.ID);
                    MyDynamicParameters.Add("@Action", Action);
                    MyDynamicParameters.Add("@vName", MyModel.vName);
                    MyDynamicParameters.Add("@mTax", MyModel.mTax);
                 

                    MyResult = con.Execute("[dbo].[ProcManageTax]", MyDynamicParameters, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                }
            }
            catch (Exception Exc)
            {
             //   Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "User_Repository", vAction = "GetEntity_List", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyResult;
        }
    }
}