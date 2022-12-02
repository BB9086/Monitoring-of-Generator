using MagneticMonitoringApp.Common;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MagneticMonitoringApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //If you do this in the WebApiConfig you will get JSON by default, 
            //but it will still allow you to return XML if you pass text/xml as the request Accept header
            //return json instead of xml by default - https://stackoverflow.com/questions/9847564/how-do-i-get-asp-net-web-api-to-return-json-instead-of-xml-using-chrome
            config.Formatters.JsonFormatter.SupportedMediaTypes
    .Add(new MediaTypeHeaderValue("text/html"));

            //format json - page 16. Web Api
            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                            Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            //Enable cross-origin resource sharing, for WEB API
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            //If a  request is isued using http, automatically redirect to https
            config.Filters.Add(new RequireHttpsAttribute());
        }
    }
}
