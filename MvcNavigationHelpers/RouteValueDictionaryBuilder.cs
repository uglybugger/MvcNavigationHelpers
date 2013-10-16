using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcNavigationHelpers
{
    internal static class RouteValueDictionaryBuilder
    {
        public static string ExtractArea(Type controllerType)
        {
            var tokens = controllerType.FullName.Split('.');
            var areaIndex = Array.IndexOf(tokens, "Areas");
            if (areaIndex < 0) return null;
            return tokens[areaIndex + 1];
        }

        public static string ExtractController(Type controllerType)
        {
            var controller = controllerType.Name.Replace("Controller", String.Empty);
            return controller;
        }

        public static string ExtractAction<TController>(Expression<Func<TController, ActionResult>> expr) where TController : IController
        {
            return ExtractAction(((MethodCallExpression)expr.Body).Method);
        }

        public static string ExtractAction(MethodInfo methodInfo)
        {
            var action = methodInfo.Name;
            return action;
        }

        private static IEnumerable<KeyValuePair<string, object>> ExtractParameters<TController>(Expression<Func<TController, ActionResult>> expr) where TController : IController
        {
            var mce = (MethodCallExpression)expr.Body;

            var methodParameters = mce.Method.GetParameters();
            for (var i = 0; i < methodParameters.Length; i++)
            {
                var argExpr = mce.Arguments[i];

                var key = methodParameters[i].Name;
                var value = ExtractValueFromArgumentExpression(argExpr);

                yield return new KeyValuePair<string, object>(key, value);
            }
        }

        private static object ExtractValueFromArgumentExpression(Expression argExpr)
        {
            // http://stackoverflow.com/questions/2616638/access-the-value-of-a-member-expression
            var objectMember = Expression.Convert(argExpr, typeof(object));
            var getterLambda = Expression.Lambda<Func<object>>(objectMember);
            var getter = getterLambda.Compile();
            var value = getter();
            return value;
        }

        public static RouteValueDictionary ExtractRouteValues<TController>(Expression<Func<TController, ActionResult>> expr) where TController : IController
        {
            var area = ExtractArea(typeof(TController));
            var controller = ExtractController(typeof(TController));
            var action = ExtractAction(expr);
            var parameters = ExtractParameters(expr);

            var routeValueDictionary = new RouteValueDictionary();
            foreach (var kvp in parameters) routeValueDictionary[kvp.Key] = kvp.Value;
            routeValueDictionary["area"] = area;
            routeValueDictionary["controller"] = controller;
            routeValueDictionary["action"] = action;

            return routeValueDictionary;
        }
    }
}