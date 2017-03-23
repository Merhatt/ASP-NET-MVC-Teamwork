using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VideoGameStore.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GamesPage",
                url: "gamespage",
                defaults: new { controller = "GamesPage", action = "Index" }
            );

            routes.MapRoute(
                name: "GameInfoReview",
                url: "GameInfo/AddReview",
                defaults: new { controller = "GameInfo", action = "AddReview" }
            );

            routes.MapRoute(
                name: "GameInfo",
                url: "gameinfo/{id}",
                defaults: new { controller = "GameInfo", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
