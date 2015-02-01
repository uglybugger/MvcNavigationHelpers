using System;
using System.Web.Mvc;

namespace MvcNavigationHelpers.UnitTests
{
    public class TestController : Controller
    {
        public ActionResult SimpleMethodWithNoParameters()
        {
            throw new NotSupportedException("I exist only so that you can find this method. I'm not for calling!");
        }

        public ActionResult MethodWithOneParameter(int foo)
        {
            throw new NotSupportedException("I exist only so that you can find this method. I'm not for calling!");
        }

        public ActionResult MethodWithSeveralParameters(int foo, bool bar, string baz)
        {
            throw new NotSupportedException("I exist only so that you can find this method. I'm not for calling!");
        }

        public RedirectResult MethodWithRedirectResult()
        {
            throw new NotSupportedException("I exist only so that you can find this method. I'm not for calling!");
        }
    }
}