using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Thinkbridge.ShopBridge
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Initialize log4net.
            log4net.Config.XmlConfigurator.Configure();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
