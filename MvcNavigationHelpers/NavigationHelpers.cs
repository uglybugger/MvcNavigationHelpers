using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcNavigationHelpers
{
    public static class NavigationHelpers
    {
        public static string UrlFor<TController, TActionResult>(this UrlHelper url, Expression<Func<TController, TActionResult>> expr)
            where TController : IController
            where TActionResult : ActionResult
        {
            var routeValueDictionary = RouteValueDictionaryBuilder.ExtractRouteValues(expr);
            var action = (string) routeValueDictionary["action"];
            var controller = (string) routeValueDictionary["controller"];
            return url.Action(action, controller, routeValueDictionary);
        }

        public static string UrlFor<TController, TActionResult>(this UrlHelper url, Expression<Func<TController, Task<TActionResult>>> expr)
            where TController : IController
            where TActionResult : ActionResult
        {
            var routeValueDictionary = RouteValueDictionaryBuilder.ExtractRouteValues(expr);
            var action = (string) routeValueDictionary["action"];
            var controller = (string) routeValueDictionary["controller"];
            return url.Action(action, controller, routeValueDictionary);
        }

        public static MvcHtmlString ActionLinkFor<TController, TActionResult>(this HtmlHelper html, Expression<Func<TController, TActionResult>> expr, string linkText)
            where TController : IController
            where TActionResult : ActionResult
        {
            var routeValueDictionary = RouteValueDictionaryBuilder.ExtractRouteValues(expr);
            var action = (string) routeValueDictionary["action"];
            var controller = (string) routeValueDictionary["controller"];

            return html.ActionLink(linkText, action, controller, routeValueDictionary);
        }

        public static MvcHtmlString ActionLinkFor<TController, TActionResult>(this HtmlHelper html, Expression<Func<TController, Task<TActionResult>>> expr, string linkText)
            where TController : IController
            where TActionResult : ActionResult
        {
            var routeValueDictionary = RouteValueDictionaryBuilder.ExtractRouteValues(expr);
            var action = (string) routeValueDictionary["action"];
            var controller = (string) routeValueDictionary["controller"];

            return html.ActionLink(linkText, action, controller, routeValueDictionary);
        }

        public static MvcHtmlString ActionFor<TController, TActionResult>(this HtmlHelper html, Expression<Func<TController, TActionResult>> expr)
            where TController : IController
            where TActionResult : ActionResult
        {
            var routeValueDictionary = RouteValueDictionaryBuilder.ExtractRouteValues(expr);
            var action = (string) routeValueDictionary["action"];
            var controller = (string) routeValueDictionary["controller"];

            return html.Action(action, controller, routeValueDictionary);
        }

        public static MvcHtmlString ActionFor<TController, TActionResult>(this HtmlHelper html, Expression<Func<TController, Task<TActionResult>>> expr)
            where TController : IController
            where TActionResult : ActionResult
        {
            var routeValueDictionary = RouteValueDictionaryBuilder.ExtractRouteValues(expr);
            var action = (string) routeValueDictionary["action"];
            var controller = (string) routeValueDictionary["controller"];

            return html.Action(action, controller, routeValueDictionary);
        }
    }
}