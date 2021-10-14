using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NewsArticle.App_Start
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        readonly string role;
        public CustomAuthorize(string role)
        {
            this.role = role;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var userType = Convert.ToString(HttpContext.Current.Session["usertype"]);
            if (userType == role)
            {
                //base.OnAuthorization(filterContext);
                if (filterContext == null)
                    throw new ArgumentException("filterContext");
                return;
               
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                   new RouteValueDictionary
                   {
                    { "controller", "Home" },
                    { "action", "Index" }
                   });
            }
        }


    }
}