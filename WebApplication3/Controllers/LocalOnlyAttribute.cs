using System;
using System.Net;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    internal class LocalOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var ip = filterContext.HttpContext.Request.UserHostAddress;   //限定某些ip才能用
            if (!filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}