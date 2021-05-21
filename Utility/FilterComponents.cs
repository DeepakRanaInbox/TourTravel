using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using TourTravel.Models;
using UtilizationTrackerApp.Models;

namespace UtilizationTrackerApp.Utility
{
 
    public class MyAuthorizationFilters : ActionFilterAttribute, IAuthorizationFilter
    {
        public string Role  { get; set; }
        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {

            if (!string.IsNullOrEmpty(SessionComponent.UName))
            {
                if (string.IsNullOrEmpty(Role) ||  this.Role.Split(',').Where(var => var == SessionComponent.RoleName).Count() <= 0)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "UnAuthorized", action = "LogOut" }));
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "LogOut" }));
            }
             
        }
         
    }
     
    public class MyExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {

            Error_Component.ManageError(new Error_DTO { vAction_Type = "MyExceptionFilter", vController = filterContext.RouteData.Values["controller"].ToString(), 
                vAction = filterContext.RouteData.Values["action"].ToString(), 
                vError_Message = filterContext.Exception.Message, vError_Line = "", vInput_Values = "", vRemarks = filterContext.Exception.StackTrace
            });
  
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };
        }
    }



    public class MyAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionComponent.UName))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "LogOut", msg= "User is not Authenticated!" }));
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {

        }
    }

    public class ActionTimeFilter : ActionFilterAttribute
    {
        Stopwatch stopwatch = new Stopwatch();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopwatch.Restart();
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            stopwatch.Stop();
            TimeSpan timeTakenByActionMethod = stopwatch.Elapsed;
            //save this time to database for tunning purpose or any other.
        }
    }
}