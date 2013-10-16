using System.Web.Routing;
using NUnit.Framework;
using Shouldly;

namespace MvcNavigationHelpers.UnitTests
{
    [TestFixture]
    public class WhenExtractingRouteValuesFromAControllerActionWithOneParameter
    {
        private RouteValueDictionary _routeValues;

        [SetUp]
        public void SetUp()
        {
            _routeValues = RouteValueDictionaryBuilder.ExtractRouteValues<TestController>(c => c.MethodWithOneParameter(42));
        }

        [Test]
        public void TheControllerShouldBeCorrect()
        {
            _routeValues["controller"].ShouldBe("Test");
        }

        [Test]
        public void TheActionMethodShouldBeCorrect()
        {
            _routeValues["action"].ShouldBe("MethodWithOneParameter");
        }

        [Test]
        public void ThereShouldBeARouteValueCalledFooWithAValueOf42()
        {
            _routeValues["foo"].ShouldBe(42);
        }
    }
}