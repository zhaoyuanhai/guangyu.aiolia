using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace AloliaProject.Models
{
    public class CustomAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string str = System.Web.HttpContext.Current.Request.RawUrl;

            var handler = HttpContext.Current.CurrentHandler as System.Web.Mvc.MvcHandler;
            // handler.RequestContext.HttpContext

            //handler.RequestContext.RouteData.

            object[] filters = filterContext.ActionDescriptor.GetCustomAttributes(false);
            object[] allFilters = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(false);


            if (allFilters.Any(e => e.GetType() == typeof(CustomAuthorizeAttribute)))
            {
                if (!allFilters.Any(e => e.GetType() == typeof(AllowAnonymousAttribute)))
                {
                    if (HttpContext.Current.Request.Cookies["aiolia"] == null)
                    {
                        if (str.ToLower() != "/manager/login")
                            filterContext.Result = new RedirectResult("/manager/login");
                    }
                }
            }
        }
    }
}