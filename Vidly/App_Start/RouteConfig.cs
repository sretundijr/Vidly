using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        { 
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //this is the attribute based routing
            routes.MapMvcAttributeRoutes();

            //this is a conventional way of setting up custom routes MVC 5 introduces a new way
            //first arg is the name, second is the path, third is the anonymous object that looks into the controller
            //and finds the matching method, fourth is regex for a four digit year and two digit month
            //routes.MapRoute("MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new { controller = "Movies", action = "ByReleaseDate" },
            //    new { year = @"\d{4}", month = @"\d{2}" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
