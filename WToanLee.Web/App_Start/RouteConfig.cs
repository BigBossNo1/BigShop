using System.Web.Mvc;
using System.Web.Routing;

namespace WToanLee.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //LOGIN
            routes.MapRoute(
                name: "Login",
                url: "page-login",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                namespaces: new string[] { "WToanLee.Web.Controllers" }
            );
            //ABOUT
            routes.MapRoute(
                name: "About",
                url: "trang-gioi-thieu.html",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WToanLee.Web.Controllers" }
            );
            routes.MapRoute(
                name: "Home Client",
                url: "home",
                defaults: new { controller = "HomeClient", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WToanLee.Web.Controllers" }
            );
            // PRODUCT CATEGORY
            routes.MapRoute(
                 name: "Product Category",
                 url: "{alias}-pc-{id}",
                 defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                 namespaces: new string[] { "WToanLee.Web.Controllers" }
            );
            // PRODUCT
            routes.MapRoute(
                 name: "Product details",
                  url: "{alias}-p-{id}",
                 defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                 namespaces: new string[] { "WToanLee.Web.Controllers" }
            );
            // TAGS
            routes.MapRoute(
                 name: "Tags List",
                  url: "tag/{tagid}/html",
                 defaults: new { controller = "Product", action = "ListByTag", tagid = UrlParameter.Optional },
                 namespaces: new string[] { "WToanLee.Web.Controllers" }
            );
            // SEARCH
            routes.MapRoute(
                 name: "Search",
                  url: "tim-kiem",
                 defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
                 namespaces: new string[] { "WToanLee.Web.Controllers" }
            );
            //QR
            routes.MapRoute(
                name: "QR",
                url: "QRCode/QRCodeDetail/{link}",
                defaults: new { controller = "QRCode", action = "QRCodeDetail", link = UrlParameter.Optional },
                namespaces: new string[] { "WToanLee.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WToanLee.Web.Controllers" }
            );
        }
    }
}