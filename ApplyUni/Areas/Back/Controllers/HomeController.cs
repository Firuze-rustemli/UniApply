using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyUni.Models;
using System.Web.Helpers;

namespace ApplyUni.Areas.Back.Controllers
{
    public class HomeController : Controller
    {
        ApplyEntities3 db = new ApplyEntities3();
        // GET: Back/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Out()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Adm_User usr)
        {
            Adm_User enterUser = db.Adm_User.FirstOrDefault(u => u.email == usr.email);
            if (enterUser != null)
            {
                if (Crypto.VerifyHashedPassword(enterUser.password, usr.password))
                {
                    Session["Loginned"] = true;
                    Session["userId"] = enterUser.id;
                    Session["userLevel"] = enterUser.user_level;
                    Session["userName"] = enterUser.fullname;
                    Session["userPhoto"] = enterUser.photo;
                    return RedirectToAction("index", "dashboard");
                }
            }
            Session["LoginValid"] = true;
            return RedirectToAction("index");
        }
    }
}