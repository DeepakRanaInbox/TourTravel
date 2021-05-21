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
    public class TaxMasterController : Controller
    {
        // GET: TaxMaster
        Tax_Repository MyTax_Repository = new Tax_Repository();
        // GET: VehicleType
        public ActionResult Index()
        {
            MasterData_DTO MyModel = new MasterData_DTO();
            MyModel.MasterList = MyTax_Repository.GetTaxMaster();

            return View(MyModel);
        }


        [HttpPost]
        public ActionResult Create(MasterData_DTO MyModel)
        {

            if (string.IsNullOrEmpty(MyModel.ID) || Convert.ToInt32(MyModel.ID) == 0)
            {

                if (MyTax_Repository.ManageTaxMaster(MyModel, "Post"))
                    TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Success, "Data Inserted Successfully!");
                else
                    TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Info, "Data not Inserted!");

            }
            else
            {

                if (MyTax_Repository.ManageTaxMaster(MyModel, "Put"))
                    TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Success, "Data Updated Successfully!");
                else
                    TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Info, "Data not Updated!");

            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            MasterData_DTO MyModel = MyTax_Repository.GetTaxMaster().Where(var => var.ID == id).FirstOrDefault();
            MyModel.MasterList = MyTax_Repository.GetTaxMaster();

            return View("Index", MyModel);
        }
        public ActionResult Delete(string id)
        {

            if (MyTax_Repository.ManageTaxMaster(new MasterData_DTO { ID = id }, "Delete"))
                TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Success, "Data Inserted Successfully!");
            else
                TempData["Notification"] = Notification_Component.SetNotification((int)Notification_Component.Result.Info, "Data not Inserted!");


            return RedirectToAction("Index");
        }
    }
}