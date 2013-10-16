using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcNavigationHelpers
{
    public static class NavigationHelpers
    {
        public static string UrlFor<TController>(this UrlHelper url, Expression<Func<TController, ActionResult>> expr) where TController : IController
        {
            var routeValueDictionary = RouteValueDictionaryBuilder.ExtractRouteValues(expr);
            var action = (string) routeValueDictionary["action"];
            var controller = (string) routeValueDictionary["controller"];
            return url.Action(action, controller, routeValueDictionary);
        }

        public static MvcHtmlString ActionLinkFor<TController>(this HtmlHelper html, Expression<Func<TController, ActionResult>> expr, string linkText)
            where TController : IController
        {
            var routeValueDictionary = RouteValueDictionaryBuilder.ExtractRouteValues(expr);
            var action = (string) routeValueDictionary["action"];
            var controller = (string) routeValueDictionary["controller"];

            return html.ActionLink(linkText, action, controller, routeValueDictionary);
        }

        public static MvcHtmlString ActionFor<TController>(this HtmlHelper html, Expression<Func<TController, ActionResult>> expr) where TController : IController
        {
            var routeValueDictionary = RouteValueDictionaryBuilder.ExtractRouteValues(expr);
            var action = (string) routeValueDictionary["action"];
            var controller = (string) routeValueDictionary["controller"];

            return html.Action(action, controller, routeValueDictionary);
        }
    }
}