using ApplyUni.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyUni.Filter;

namespace ApplyUni.Areas.Back.Controllers
{
    [Auth]
    public class CalendarController : Controller
    {
        // GET: Back/Calendar
        public ActionResult Index()
        {
            return View();
        }
    }
}