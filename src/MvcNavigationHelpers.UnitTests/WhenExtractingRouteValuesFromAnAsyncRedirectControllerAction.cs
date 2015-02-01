using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;
using Shouldly;

namespace MvcNavigationHelpers.UnitTests
{
    public class WhenExtractingRouteValuesFromAnAsyncRedirectControllerAction
    {
        private RouteValueDictionary _routeValues;

        [SetUp]
        public void SetUp()
        {
            _routeValues = RouteValueDictionaryBuilder.ExtractRouteValues<TestAsyncController, RedirectResult>(c => c.MethodWithRedirectResult());
        }

        [Test]
        public void TheControllerShouldBeCorrect()
        {
            _routeValues["controller"].ShouldBe("TestAsync");
        }

        [Test]
        public void TheActionMethodShouldBeCorrect()
        {
            _routeValues["action"].ShouldBe("MethodWithRedirectResult");
        }
    }
}