using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TourTravel.Models;

namespace TourTravel.BLL
{
    public class Account_Repository
    {
        public Login_DTO AuthenticationUser(Login_Model MyModel)
        {
            Login_DTO MyModelList = new Login_DTO();

            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {

                    DynamicParameters MyDynamicParameters = new DynamicParameters();

                    MyDynamicParameters.Add("@LoginID", MyModel.vLoginID);
                    MyDynamicParameters.Add("@Password", MyModel.vPassword);


                    MyModelList = con.Query<Login_DTO>("ProcLoginUser", MyDynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception Exc)
            {
              //  Error_Component.ManageError(new Error_DTO { vAction_Type = "Repository", vController = "Account_Repository", vAction = "AuthenticationUser", vError_Message = Exc.Message, vError_Line = "", vInput_Values = "", vRemarks = "" });
            }

            return MyModelList;
        }
    }
}