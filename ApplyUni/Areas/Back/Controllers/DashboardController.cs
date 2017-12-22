using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyUni.Models;
using ApplyUni.Filter;

namespace ApplyUni.Areas.Back.Controllers
{
    [Auth]
    public class DashboardController : Controller
    {
        ApplyEntities3 db = new ApplyEntities3();
        // GET: Back/Dashboard

        public ActionResult Index()
        {
            //ViewBag.Post = db.Adm_User.FirstOrDefault(u => u.id == u.id);
            return View();
        }

        //logout
        public ActionResult Logout()
        {
            Session["Loginned"] = null;
            return RedirectToAction("Out", "home");
        }
        //cantaccss
        public ActionResult CantAcss()
        {
            return View();
        }

        //profile
     
    }
}