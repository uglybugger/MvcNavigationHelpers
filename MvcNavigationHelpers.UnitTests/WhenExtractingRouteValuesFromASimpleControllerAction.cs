using System.Web.Routing;
using NUnit.Framework;
using Shouldly;

namespace MvcNavigationHelpers.UnitTests
{
    [TestFixture]
    public class WhenExtractingRouteValuesFromASimpleControllerAction
    {
        private RouteValueDictionary _routeValues;

        [SetUp]
        public void SetUp()
        {
            _routeValues = RouteValueDictionaryBuilder.ExtractRouteValues<TestController>(c => c.SimpleMethodWithNoParameters());
        }

        [Test]
        public void TheControllerShouldBeCorrect()
        {
            _routeValues["controller"].ShouldBe("Test");
        }

        [Test]
        public void TheActionMethodShouldBeCorrect()
        {
            _routeValues["action"].ShouldBe("SimpleMethodWithNoParameters");
        }
    }
}