using System.Web.Mvc;
using System.Web.Routing;

namespace MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "UserPage",
                url: "User/{user}",
                defaults: new { controller = "User", action = "User", user = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "UserPages",
                url: "User/{user}/Page/{page}",
                defaults: new { controller = "User", action = "Page", user = UrlParameter.Optional, page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PhotoPage",
                url: "Page/{page}",
                defaults: new { controller = "Photo", action = "Page", page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}