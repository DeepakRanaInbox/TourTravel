using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourTravel.BLL;
using TourTravel.Models;
using UtilizationTrackerApp.Utility;

namespace TourTravel.Controllers
{
    [MyAuthenticationFilter]
    public class VehicleTypeController : Controller
    {

        VehicleTypeRepository MyTravel_Repository = new VehicleTypeRepository();
        // GET: VehicleType
        public ActionResult Index()
        {
            VehicleType_Model MyModel = new VehicleType_Model();
            MyModel.VehicleTypeList = MyTravel_Repository.GetEntity_List();

            return View(MyModel);
        }

 
        [HttpPost]
        public ActionResult Create(VehicleType_Model MyModel)
        {

            if (string.IsNullOrEmpty(MyModel.ID) || Convert.ToInt32(MyModel.ID)==0)
            {

                if (MyTravel_Repository.ManageEntity(MyModel, "Post"))
                    TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Success, "Data Inserted Successfully!");
                else
                    TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Info, "Data not Inserted!");

            }
            else
            {
  
                if (MyTravel_Repository.ManageEntity(MyModel, "Put"))
                    TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Success, "Data Updated Successfully!");
                else
                    TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Info, "Data not Updated!");

            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            VehicleType_Model MyModel = MyTravel_Repository.GetEntity_List().Where(var=> var.ID==id).FirstOrDefault();
            MyModel.VehicleTypeList = MyTravel_Repository.GetEntity_List();

            return View("Index", MyModel);
        }
        public ActionResult Delete(string id)
        {
          
            if (MyTravel_Repository.ManageEntity(new VehicleType_Model { ID = id }, "Delete"))
                TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Success, "Data Inserted Successfully!");
            else
                TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Info, "Data not Inserted!");


            return RedirectToAction("Index");
        }
    }
}