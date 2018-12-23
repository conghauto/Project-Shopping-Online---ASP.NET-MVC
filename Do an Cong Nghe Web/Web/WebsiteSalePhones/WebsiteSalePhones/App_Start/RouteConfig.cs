using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebsiteSalePhones
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*botdetect}",
       new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
               name: "Add Cart",
               url: "them-gio-hang",
               defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "WebsiteSalePhones.Controllers" }
            );
            routes.MapRoute(
              name: "Search",
              url: "tim-kiem",
              defaults: new { controller = "Phone", action = "Search", id = UrlParameter.Optional },
               namespaces: new[] { "WebsiteSalePhones.Controllers" }
           );
            routes.MapRoute(
              name: "Login",
              url: "dang-nhap",
              defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
               namespaces: new[] { "WebsiteSalePhones.Controllers" }
           );
            routes.MapRoute(
            name: "Payment Success",
            url: "hoan-thanh",
            defaults: new { controller = "Cart", action = "Sucess", id = UrlParameter.Optional },
             namespaces: new[] { "WebsiteSalePhones.Controllers" }
         );
            routes.MapRoute(
             name: "Payment Error",
             url: "loi-thanh-toan",
             defaults: new { controller = "Cart", action = "Error", id = UrlParameter.Optional },
              namespaces: new[] { "WebsiteSalePhones.Controllers" }
          );
            routes.MapRoute(
             name: "Payment",
             url: "thanh-toan",
             defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
              namespaces: new[] { "WebsiteSalePhones.Controllers" }
          );
            routes.MapRoute(
              name: "Cart",
              url: "gio-hang",
              defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "WebsiteSalePhones.Controllers" }
           );
            routes.MapRoute(
             name: "Register",
             url: "dang-ki",
             defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
              namespaces: new[] { "WebsiteSalePhones.Controllers" }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home",action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "WebsiteSalePhones.Controllers" }
            );

        }
    }
}
