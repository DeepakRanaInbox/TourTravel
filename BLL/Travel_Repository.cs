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
    public class Travel_Repository
    {

        public List<TravelTax_Model> GetTravelTax_List(int TravelID)
        {
            List<TravelTax_Model> MyModelList = new List<TravelTax_Model>();

            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {
                    DynamicParameters MyDynamicParameters = new DynamicParameters();
                     
                    MyDynamicParameters.Add("@iTravelID", TravelID);
                   
                    MyModelList = con.Query<TravelTax_Model>("ProcGetTravelTax", MyDynamicParameters, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch (Exception Exc)
            {
                Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "Client_Repository", vAction = "GetEntity_List", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyModelList;
        }
        public List<TravelHistory_Model> GetEntity_List(string Action, TravelHistory_Model MyModel)
        {
            List<TravelHistory_Model> MyModelList = new List<TravelHistory_Model>();
             
            try
            {
                 
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString)) 
                {
                    DynamicParameters MyDynamicParameters = new DynamicParameters();
 

                    MyDynamicParameters.Add("@Action", Action);
                    MyDynamicParameters.Add("@iTravelID", MyModel.iTravelID);
       
                    MyModelList = con.Query<TravelHistory_Model>("ProcGetTravelHistory", MyDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
 
                }
            }
            catch (Exception Exc)
            {
                Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "Client_Repository", vAction = "GetEntity_List", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyModelList;
        }

        public int InsertTravelHistory(TravelHistory_Model MyModel)
        {
            int MyResult = 0;

            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {
                    DynamicParameters MyDynamicParameters = new DynamicParameters();


                    MyDynamicParameters.Add("@vUserName", MyModel.vUserName);
                    MyDynamicParameters.Add("@vUserPhoneNo", MyModel.vUserPhoneNo);
                    MyDynamicParameters.Add("@vAddress", MyModel.vAddress);
                    MyDynamicParameters.Add("@vPartyGSTIN", MyModel.vPartyGSTIN);
                    MyDynamicParameters.Add("@vDriverName", MyModel.vDriverName);
                    MyDynamicParameters.Add("@vDriverPhoneNo", MyModel.vDriverPhoneNo);

                    MyDynamicParameters.Add("@vFromToPlace", MyModel.vFromToPlace);
                    MyDynamicParameters.Add("@vVehicleNo", MyModel.vVehicleNo);
                    MyDynamicParameters.Add("@iVehicleType", MyModel.iVehicleType);
                    MyDynamicParameters.Add("@dStartingDate", MyModel.dStartingDate);
                    MyDynamicParameters.Add("@dClosingDate", MyModel.dClosingDate);
                    MyDynamicParameters.Add("@iHoliday", MyModel.iHoliday);
                    MyDynamicParameters.Add("@iTotalDays", MyModel.iTotalDays);
                    MyDynamicParameters.Add("@iStartingKM", MyModel.iStartingKM);
                    MyDynamicParameters.Add("@iClosingKM", MyModel.iClosingKM);
                    MyDynamicParameters.Add("@iTotalKM", MyModel.iTotalKM);

                    MyDynamicParameters.Add("@iTravelID", dbType: DbType.String, direction: ParameterDirection.Output, size: 10);

                    con.Execute("ProcInsertTravelHistory", MyDynamicParameters, commandType: CommandType.StoredProcedure);

                    MyResult = Convert.ToInt32(MyDynamicParameters.Get<string>("@iTravelID"));
                }
            }
            catch (Exception Exc)
            {
                Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "Client_Repository", vAction = "GetEntity_List", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyResult;
        }


        public bool InsertTravelAmount(TravelHistory_Model MyModel)
        {
            bool MyResult = false;

            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {
                    DynamicParameters MyDynamicParameters = new DynamicParameters();
 
                    MyDynamicParameters.Add("@iTravelID", MyModel.iTravelID);
                    MyDynamicParameters.Add("@mPerKMChangres", MyModel.mPerKMChangres);
                    MyDynamicParameters.Add("@mPerDayChangres", MyModel.mPerDayChangres);
                    MyDynamicParameters.Add("@mNightChangres", MyModel.mNightChangres);
                    MyDynamicParameters.Add("@mTollTaxAndParking", MyModel.mTollTaxAndParking);
                    MyDynamicParameters.Add("@mTotalAmountBeforeTax", MyModel.mTotalAmountBeforeTax);

                    MyDynamicParameters.Add("@mDiscountAmount", MyModel.mDiscountAmount);
                    MyDynamicParameters.Add("@vDiscountRemarks", MyModel.vDiscountRemarks);
                    MyDynamicParameters.Add("@mTotalTaxAmount", MyModel.mTotalTaxAmount);

                    MyResult = con.Execute("ProcInsertTravelAmount", MyDynamicParameters, commandType: CommandType.StoredProcedure) >0 ? true : false;
                     
                }
            }
            catch (Exception Exc)
            {
                Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "Client_Repository", vAction = "GetEntity_List", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyResult;
        }

        public bool InsertTravelTax(TravelTax_Model MyModel)
        {
            bool MyResult = false;

            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {
                    DynamicParameters MyDynamicParameters = new DynamicParameters();

                 
                    MyDynamicParameters.Add("@iTravelID", MyModel.iTravelID);
                    MyDynamicParameters.Add("@iTaxID", MyModel.iTaxID);
                    MyDynamicParameters.Add("@mTax", MyModel.mTax);
                    MyDynamicParameters.Add("@mTaxAmount", MyModel.mTaxAmount);
         

                    MyResult = con.Execute("ProcInsertTravelTax", MyDynamicParameters, commandType: CommandType.StoredProcedure) > 0 ? true : false;

                }
            }
            catch (Exception Exc)
            {
                Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "Client_Repository", vAction = "GetEntity_List", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyResult;
        }
    }
}