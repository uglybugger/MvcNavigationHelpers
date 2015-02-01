using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcNavigationHelpers
{
    public static class NavigationHelperCommonFacades
    {
        public static string UrlFor<TController>(this UrlHelper url, Expression<Func<TController, ActionResult>> expr)
            where TController : IController
        {
            return url.UrlFor<TController, ActionResult>(expr);
        }

        public static string UrlFor<TController>(this UrlHelper url, Expression<Func<TController, Task<ActionResult>>> expr)
            where TController : IController
        {
            return url.UrlFor<TController, ActionResult>(expr);
        }

        public static MvcHtmlString ActionLinkFor<TController>(this HtmlHelper html, Expression<Func<TController, ActionResult>> expr, string linkText)
            where TController : IController
        {
            return html.ActionLinkFor<TController, ActionResult>(expr, linkText);
        }

        public static MvcHtmlString ActionLinkFor<TController>(this HtmlHelper html, Expression<Func<TController, Task<ActionResult>>> expr, string linkText)
            where TController : IController
        {
            return html.ActionLinkFor<TController, ActionResult>(expr, linkText);
        }

        public static MvcHtmlString ActionFor<TController>(this HtmlHelper html, Expression<Func<TController, ActionResult>> expr)
            where TController : IController
        {
            return html.ActionFor<TController, ActionResult>(expr);
        }

        public static MvcHtmlString ActionFor<TController>(this HtmlHelper html, Expression<Func<TController, Task<ActionResult>>> expr)
            where TController : IController
        {
            return html.ActionFor<TController, ActionResult>(expr);
        }
    }
}