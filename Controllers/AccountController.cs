using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourTravel.BLL;
using TourTravel.Models;
using TourTravel.Repository;
using UtilizationTrackerApp.Utility;

namespace TourTravel.Controllers
{
    public class AccountController : Controller
    {
        Account_Repository MyRepository;
        public AccountController()
        {
            MyRepository = new Account_Repository();
        }


        public ActionResult Login()
        {
            Login_Model MyModel = new Login_Model();
 
            return View(MyModel);
        }

        public ActionResult LogOut()
        {
            SessionComponent.ClearSession();

            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login_Model MyModel)
        {
               
            
                Login_DTO MyLogin_DTO = MyRepository.AuthenticationUser(MyModel);

                if (MyLogin_DTO != null && MyLogin_DTO.Result.StartsWith("success"))
                {

                    MyLogin_DTO.Result = MyLogin_DTO.Result.Replace("success:", "");
                    SessionComponent.UID = MyLogin_DTO.ID;
                    SessionComponent.UName = MyLogin_DTO.vName;
                    
                    SessionComponent.SessionID = Session.SessionID;
                 
                    return RedirectToAction("Index", "Travel");
                }
                else if (MyLogin_DTO != null && MyLogin_DTO.Result.StartsWith("fail"))
                {
                    MyLogin_DTO.Result = MyLogin_DTO.Result.Replace("fail:", "");
                    TempData["msg"] = MyLogin_DTO.Result;
                    TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Info, MyLogin_DTO.Result);

                return RedirectToAction("Login");
                }
                else
                {
                    TempData["msg"] = "Invalid credentials,Please try again!";
                    TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Info, "Invalid credentials,Please try again!");

                    return RedirectToAction("Login");

                // TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Info, "Invalid credentials,Please try again!");
            }

          
            

        }

    }
}