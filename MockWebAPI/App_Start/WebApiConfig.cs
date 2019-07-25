using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MockWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API の設定およびサービス
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Add(config.Formatters.JsonFormatter);

            // Web API ルート
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{id1}/{id2}/{id3}/{id4}/{id5}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    id1 = RouteParameter.Optional,
                    id2 = RouteParameter.Optional,
                    id3 = RouteParameter.Optional,
                    id4 = RouteParameter.Optional,
                    id5 = RouteParameter.Optional,
                }
            );
        }
    }
}
