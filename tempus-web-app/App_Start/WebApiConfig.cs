﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace TempusWebApp
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      IocConfig.SetupSimpleInjector();

      // Web API configuration and services
      var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
      json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

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
