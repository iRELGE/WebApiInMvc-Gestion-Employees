using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web
          
           
            // Itinéraires de l'API Web

            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // Autorize asp.net projet named MVC to consome Api
            config.EnableCors(new EnableCorsAttribute("http://localhost:50230/", headers: "*", methods: "*"));
            // Autorize Angular8 projet named Apiconsomateur to consome Api
            //config.EnableCors(new EnableCorsAttribute("http://localhost:4200/", headers: "*", methods: "*"));
        }
    }
}
