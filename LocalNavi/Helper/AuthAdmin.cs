using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalNavi.Helper
{
    public class AuthAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["AdminLogin"] == null)
            {
                filterContext.Result = new RedirectResult("~/manage/admin/index");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}