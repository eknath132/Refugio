using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Refugio.Controllers;
using Refugio.Models;

namespace Refugio.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           

            var oUser = (Adm)HttpContext.Current.Session["User"];

            if(oUser == null)
            {
                if(filterContext.Controller is TablaController is true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/index");
                }
            }
            if (oUser?.USUARIO == "admin")
            {
                if (filterContext.Controller is AccessController is true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/index");
                }
            }
            if (oUser?.USUARIO != "admin")
            {
                if (filterContext.Controller is LoginController is true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Tabla/index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}