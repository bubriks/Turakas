﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCPresentationTier
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "ChatRoom",
                "Message/ChatRoom/{chatId}/{profileId}",
                new { controller = "Message", action = "ChatRoom", chatId = UrlParameter.Optional, profileId = UrlParameter.Optional }
            );

            routes.MapRoute(
                "GetChat",
                "Chat/GetChat/{chat}/",
                new { controller = "Chat", action = "GetChat", chat = UrlParameter.Optional }
            );

            routes.MapRoute(
                "GetChats",
                "Chat/GetChats/{input}/{profileId}",
                new { controller = "Chat", action = "GetChats", input = UrlParameter.Optional , profileId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
