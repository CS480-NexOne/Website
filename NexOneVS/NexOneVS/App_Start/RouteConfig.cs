﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NexOneVS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Movie",
                url: "Movies/Title/{id}",
                defaults: new { controller = "Movies", action = "Title", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Game",
                url: "Games/Title/{id}",
                defaults: new { controller = "Games", action = "Title", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TV",
                url: "TV/Title/{id}",
                defaults: new { controller = "TV", action = "Title", id = UrlParameter.Optional }
            );

        }
    }
}
