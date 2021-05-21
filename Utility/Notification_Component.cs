using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilizationTrackerApp.Utility
{


      
    public class Notification_Component
    {
        public enum Result
        {
            Success = 1,
            Info = 2,
            Error = 3
        }

        public static List<NotificationModel> NotificationList = new List<NotificationModel>
       {
              new NotificationModel { TypeID=1,Type="Success",Header="Success Notification",Class="alert alert-block alert-success fade in",Icon="icon-like"},
              new NotificationModel { TypeID=2,Type="Info",Header="Warning Notification",Class="alert alert-block alert-info fade in",Icon="icon-question"},
              new NotificationModel { TypeID=3,Type="Error",Header="Error Notification",Class="alert alert-block alert-danger fade in",Icon="icon-shield"},
       };

        public static NotificationModel SetNotification(int Type, string sMessage)
        {
            NotificationModel MyNotificationModel = NotificationList.Where(var => var.TypeID == 3).FirstOrDefault();

            if (NotificationList.Where(var => var.TypeID == Type).Count() > 0)
                MyNotificationModel = NotificationList.Where(var => var.TypeID == Type).FirstOrDefault();

            MyNotificationModel.Message = sMessage;

            return MyNotificationModel;
        }
        public static NotificationModel SetNotification(int Type, string sMessage, List<string> MessageList)
        {
            NotificationModel MyNotificationModel = NotificationList.Where(var => var.TypeID == 3).FirstOrDefault();

            if (NotificationList.Where(var => var.TypeID == Type).Count() > 0)
                MyNotificationModel = NotificationList.Where(var => var.TypeID == Type).FirstOrDefault();

            MyNotificationModel.Message = sMessage;
            MyNotificationModel.ErrorList = MessageList;

            return MyNotificationModel;
        }
    }

    public class NotificationModel
    {
        public int TypeID { get; set; }
        public string Type { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }
        public string Class { get; set; }
        public string Icon { get; set; }
        public List<string> ErrorList { get; set; }

    }
}