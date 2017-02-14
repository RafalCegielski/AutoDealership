using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoKomisMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Admin",
                url: "Administracja/{action}",
                defaults: new { controller = "Admin", action = "Login" }
            );
            routes.MapRoute(
                name: "Ogloszenia",
                url: "ogloszenia",
                defaults: new { controller = "Advertisment", action = "AdvertismentList" }
            );
            routes.MapRoute(
                name: "Kontakt",
                url: "kontakt",
                defaults: new { controller = "Home", action = "Contact" }
            );
            routes.MapRoute(
                name: "Dojazd",
                url: "dojazd",
                defaults: new { controller = "Home", action = "Route" }
            );
            routes.MapRoute(
                name: "OgloszenieDetale",
                url: "ogloszenie-{BrandOfCar}-{ModelOfCar}_{id}",
                defaults: new { controller = "Advertisment", action = "AdvertismentDetails" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "HomePage", id = UrlParameter.Optional }
            );
        }
    }
}
