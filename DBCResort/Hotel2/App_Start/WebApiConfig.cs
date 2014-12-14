﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Hotel2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);


            config.Routes.MapHttpRoute(
               name: "DefaultApi2",
               routeTemplate: "api/{controller}/{action}/{username}/{duration}",
               defaults: new
               {
                   username = RouteParameter.Optional,
                   duration = RouteParameter.Optional
               }
           );

            config.Routes.MapHttpRoute(
              name: "DefaultApi3",
              routeTemplate: " api/{controller}/{action}",
              defaults: null
          );

            config.Routes.MapHttpRoute(
            name: "DefaultApi4",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
   );
        }
    }
}
