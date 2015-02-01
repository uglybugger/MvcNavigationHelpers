using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;
using Shouldly;

namespace MvcNavigationHelpers.UnitTests
{
    [TestFixture]
    public class WhenExtractingRouteValuesFromAControllerActionWithSeveralParameters
    {
        private RouteValueDictionary _routeValues;

        [SetUp]
        public void SetUp()
        {
            _routeValues = RouteValueDictionaryBuilder.ExtractRouteValues<TestController, ActionResult>(c => c.MethodWithSeveralParameters(42, true, "bork bork bork"));
        }

        [Test]
        public void TheControllerShouldBeCorrect()
        {
            _routeValues["controller"].ShouldBe("Test");
        }

        [Test]
        public void TheActionMethodShouldBeCorrect()
        {
            _routeValues["action"].ShouldBe("MethodWithSeveralParameters");
        }

        [Test]
        public void ThereShouldBeARouteValueCalledFooWithAValueOf42()
        {
            _routeValues["foo"].ShouldBe(42);
        }

        [Test]
        public void ThereShouldBeARouteValueCalledBarWithAValueOfTrue()
        {
            _routeValues["bar"].ShouldBe(true);
        }

        [Test]
        public void ThereShouldBeARouteValueCalledBazWithAValueOfBorkBorkBork()
        {
            _routeValues["baz"].ShouldBe("bork bork bork");
        }
    }
}