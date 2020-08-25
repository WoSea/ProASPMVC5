using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ch15_UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            /*Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            routes.Add("MyRoute", myRoute);
            */
            //routes.MapRoute("MyRoute", "{controller}/{action}");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            /*
             * routes.MapRoute("", "X{controller}/{action}");
             * routes.MapRoute("MyRoute", "{controller}/{action}",
                                       new { controller = "Home", action = "Index" });
              routes.MapRoute("", "Public/{controller}/{action}",
                                      new { controller = "Home", action = "Index" });*/
        }
    }
}
