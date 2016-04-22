using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GuaGuoTech.Com.Manager.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Default",
               url: "{modules}/{controller}/{action}/{id}",
               defaults: new { modules = "Homes", controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}