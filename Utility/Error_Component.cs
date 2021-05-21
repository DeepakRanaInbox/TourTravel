using Dapper;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using TourTravel.Models;

namespace UtilizationTrackerApp.Utility
{
    public class Error_Component
    {
        public static bool WriteErrorLogInFile(Exception excep, string Application, string Controllers, string Action, string Location, string URL, string UserID)
        {
            bool flag = false;
            try
            {
                string ErrorMessgage = excep.Message;
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(excep, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                string path = AppDomain.CurrentDomain.BaseDirectory + "Blob_Storage\\ErrorLog";
                // check if directory exists
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\ERROR_" + DateTime.Today.ToString("dd-MMM-yyyy") + ".log";
                // check if file exist
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }
                // log the error now
                using (StreamWriter writer = File.AppendText(path))
                {
                    string error = DateTime.Now.ToString() + "-Application:" + Application + ",Controller:" + Controllers + ",Action:" + Action + ",Location:" + Location + ",UserID:" + UserID + ",UserID:" + UserID + ",Message:" + excep.Message + ",URL:" + URL;
                    writer.WriteLine(error);
                    writer.Flush();
                    writer.Close();
                }
                flag = true;
            }
            catch(Exception EXC)
            { }
            return flag;
        }

        public static void ManageError(Error_DTO MyModel)
        {
            try
            {
                MyModel.vApplication =  "UtilizationTrackerApp";

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                {
                    DynamicParameters MyDynamicParameters = new DynamicParameters();
                    MyDynamicParameters.Add("@vApplication", MyModel.vApplication);
                    MyDynamicParameters.Add("@vAction_Type", MyModel.vAction_Type);
                    MyDynamicParameters.Add("@vController", MyModel.vController);
                    MyDynamicParameters.Add("@vAction", MyModel.vAction);
                    MyDynamicParameters.Add("@vError_Message", MyModel.vError_Message);
                    MyDynamicParameters.Add("@vError_Line", MyModel.vError_Line);
                    MyDynamicParameters.Add("@vInput_Values", MyModel.vInput_Values);
                    MyDynamicParameters.Add("@vRemarks", MyModel.vRemarks);

                   con.Execute("ProcInsertApplicationError_Logs", MyDynamicParameters, commandType: CommandType.StoredProcedure);
                }
                 
            }
            catch(Exception EXC)
            {
                WriteErrorLogInFile(EXC, MyModel.vApplication, MyModel.vController, MyModel.vAction, MyModel.vError_Line, MyModel.vInput_Values, MyModel.vRemarks);
            }
        
        }

    }
}