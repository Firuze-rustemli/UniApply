using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplyUni.Filter
{
    public class Admlvl : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int level = Convert.ToInt32(HttpContext.Current.Session["userLevel"]);
            if (level != 1)
            {
                filterContext.Result = new RedirectResult("~/Back/Dashboard/CantAcss");
                return;
            }
            base.OnActionExecuting(filterContext);

        }
    }
}