using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace UtilizationTrackerApp.Utility
{
    public static class HtmlHelper_Component
    {
        public static MvcHtmlString Conditional(this HtmlHelper html, Boolean condition, String ifTrue, String ifFalse)
        {
            return MvcHtmlString.Create(condition ? ifTrue : ifFalse);
        }

        public static MvcHtmlString Conditional(this HtmlHelper html, string condition, String ifTrue, String ifFalse)
        {
            return MvcHtmlString.Create(Convert.ToInt32(condition)>0 ? ifTrue : ifFalse);
        }

        public static bool Conditional(string Myvalue,int condition)
        {
            return (Convert.ToInt32(Myvalue) > condition ? true : false);
        }

        public static bool Conditional(string Myvalue1, string Myvalue2)
        {
            return (Convert.ToInt32(Myvalue1) == Convert.ToInt32(Myvalue2) ? false : true);
        }
        public static bool ConditionalForTimeSpent(string Myvalue1, string Myvalue2)
        {
            return (Convert.ToDecimal(Myvalue1) == Convert.ToDecimal(Myvalue2) ? false : true);
        }
    }
}