using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalNavi.Helper
{
    public class AuthUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["UserLogin"] == null)
            {
                filterContext.Result = new RedirectResult("~/home/index");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}