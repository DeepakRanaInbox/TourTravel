using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilizationTrackerApp.Utility
{
  

    public static class SessionComponent
    {
        public static void ClearSession()
        {
            try
            {

                SessionComponent.UID = 0;
                SessionComponent.UCode = string.Empty;
                SessionComponent.UName = string.Empty;
                SessionComponent.RoleName = string.Empty;
                SessionComponent.SessionID = string.Empty;

                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();

                //string[] myCookies = Request.Cookies.AllKeys;
                //foreach (string cookie in myCookies)
                //{
                //    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                //}
            }
            catch (Exception ex)
            {
     
            }
        }
        public static int UID
        {
            get
            {
                if (HttpContext.Current.Session["UID"] == null)
                {
                    return 0;
                }
                else
                {
                    return (Convert.ToInt32(HttpContext.Current.Session["UID"].ToString()));
                }
            }
            set
            {
                HttpContext.Current.Session["UID"] = value;
            }
        }

        public static string UCode
        {
            get
            {
                if (HttpContext.Current.Session["UCode"] == null)
                {
                    return (string.Empty);
                }
                else
                {
                    return (HttpContext.Current.Session["UCode"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["UCode"] = value;
            }
        }

        public static string UName
        {
            get
            {
                if (HttpContext.Current.Session["UName"] == null)
                {
                    return (string.Empty);
                }
                else
                {
                    return (HttpContext.Current.Session["UName"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["UName"] = value;
            }
        }



        public static string RoleName
        {
            get
            {
                if (HttpContext.Current.Session["ROLENAME"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return (HttpContext.Current.Session["ROLENAME"].ToString());
                }

            }

            set
            {
                HttpContext.Current.Session["ROLENAME"] = value;
            }

        }


 

        public static string SessionID
        {
            get
            {
                if (HttpContext.Current.Session["SessionID"] == null)
                {
                    return (string.Empty);
                }
                else
                {
                    return (HttpContext.Current.Session["SessionID"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["SessionID"] = value;
            }
        }

        public static bool bisAway
        {
            get
            {
                if (HttpContext.Current.Session["bisAway"] == null)
                {
                    return (false);
                }
                else
                {
                    return ((bool)HttpContext.Current.Session["bisAway"]);
                }
            }
            set
            {
                HttpContext.Current.Session["bisAway"] = value;
            }
        }
    }

}