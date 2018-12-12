using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OC_eBibliotheque
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Rechercher",
                url: "Rechercher/Livre/{chaine}",
                defaults: new { controller = "Rechercher", action = "Livre" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Afficher", action = "Livres", id = UrlParameter.Optional }
            );


        }
    }
}
