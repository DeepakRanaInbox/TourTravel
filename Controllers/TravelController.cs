using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourTravel.BLL;
using UtilizationTrackerApp.Models.Data;
using UtilizationTrackerApp.Utility;

namespace TourTravel.Controllers
{

    [MyAuthenticationFilter]
    public class TravelController : Controller
    {
        // GET: Travel

        Master_Repository MyMaster_Repository;
        Travel_Repository MyTravel_Repository;
        public TravelController()
        {
            MyMaster_Repository = new Master_Repository();
            MyTravel_Repository = new Travel_Repository();
        }
        public ActionResult Index()
        {
            TravelHistory_Model MyModel = new TravelHistory_Model();
            MyModel.Todaydate = new DateTime().ToString("dd/MM/YYYY");

            MyModel.VehicleType = Global_Component.FillDropdownList(MyMaster_Repository.GetMasterData("VehicleType", "", "").Where(var => var.vType == "VehicleType").Select(var => new SelectListItem { Text = var.vName, Value = var.ID }).ToList(), "--Vehicle Type--");
            MyModel.TravelTaxList = MyMaster_Repository.GetMasterData("Tax", "", "").Where(var => var.vType == "Tax").ToList();

            return View(MyModel);
        }

        [HttpPost]
        public ActionResult Index(TravelHistory_Model MyModel)
        {

            //06/01/2021 - 06/05/2021

            if (!string.IsNullOrEmpty(MyModel.dStartingDate))
            {
              
                MyModel.dClosingDate = (MyModel.dStartingDate.Split('-')[1]).TrimStart();
                MyModel.dStartingDate = (MyModel.dStartingDate.Split('-')[0]).TrimEnd();
            }


            MyModel.iTravelID = MyTravel_Repository.InsertTravelHistory(MyModel);

            if(MyModel.iTravelID>0)
            {
                MyTravel_Repository.InsertTravelAmount(MyModel);
                
                //,1:147.75,3:295.5
                if (!string.IsNullOrEmpty(MyModel.Taxitemlist))
                {
                    string[] TaxItems = MyModel.Taxitemlist.Split(',');

                    foreach (string Item in TaxItems)
                    {
                        if (Item.Split(':').Count() > 1)
                        {
                            TravelTax_Model MyObject = new TravelTax_Model();
                            MyObject.iTaxID = Item.Split(':')[0];
                            MyObject.mTaxAmount = Item.Split(':')[1];
                            MyObject.iTravelID = MyModel.iTravelID.ToString();
                            MyTravel_Repository.InsertTravelTax(MyObject);
                        }
                    }
                }
            }

            return RedirectToAction("PrintInvoice",new {id= MyModel.iTravelID });
        }
        public ActionResult _TaxGrid()
        {
            return View();
        }
        public ActionResult PrintInvoice(int id)
        {
            TravelHistory_Model MyModel = new TravelHistory_Model();
            MyModel.iTravelID = id;

            MyModel = MyTravel_Repository.GetEntity_List("GetPrintInvoice", MyModel).FirstOrDefault();
            MyModel.TaxList = MyTravel_Repository.GetTravelTax_List(id).ToList();

            return View(MyModel);
        }
        public ActionResult Details()
        {
            TravelHistory_Model MyModel = new TravelHistory_Model();
            
            MyModel.TravelHistory = MyTravel_Repository.GetEntity_List("Get",new TravelHistory_Model() {iTravelID=0 });

            return View(MyModel);
        }
    }
}