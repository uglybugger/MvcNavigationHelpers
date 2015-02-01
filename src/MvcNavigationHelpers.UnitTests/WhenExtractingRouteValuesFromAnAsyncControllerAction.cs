using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;
using Shouldly;

namespace MvcNavigationHelpers.UnitTests
{
    [TestFixture]
    public class WhenExtractingRouteValuesFromAnAsyncControllerAction
    {
        private RouteValueDictionary _routeValues;

        [SetUp]
        public void SetUp()
        {
            _routeValues = RouteValueDictionaryBuilder.ExtractRouteValues<TestAsyncController, ActionResult>(c => c.SimpleMethodWithNoParameters());
        }

        [Test]
        public void TheControllerShouldBeCorrect()
        {
            _routeValues["controller"].ShouldBe("TestAsync");
        }

        [Test]
        public void TheActionMethodShouldBeCorrect()
        {
            _routeValues["action"].ShouldBe("SimpleMethodWithNoParameters");
        }
    }
}