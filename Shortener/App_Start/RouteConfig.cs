using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shortener
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ApiRoute",
                url: "ShortLink/{action}/{key}",
                defaults: new { controller = "ShortLink", action = "Get", key = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "RedirectRoute",
                url: "{key}",
                defaults: new { controller = "Home", action = "Index", key = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{key}",
                defaults: new { controller = "Home", action = "Index", key = UrlParameter.Optional }
            );
        }
    }
}
