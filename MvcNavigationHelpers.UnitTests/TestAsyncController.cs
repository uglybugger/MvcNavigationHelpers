using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcNavigationHelpers.UnitTests
{
    public class TestAsyncController : AsyncController
    {
        public async Task<ActionResult> SimpleMethodWithNoParameters()
        {
            throw new NotSupportedException("I exist only so that you can find this method. I'm not for calling!");
        }

        public async Task<ActionResult> MethodWithOneParameter(int foo)
        {
            throw new NotSupportedException("I exist only so that you can find this method. I'm not for calling!");
        }

        public async Task<ActionResult> MethodWithSeveralParameters(int foo, bool bar, string baz)
        {
            throw new NotSupportedException("I exist only so that you can find this method. I'm not for calling!");
        }

        public async Task<RedirectResult> MethodWithRedirectResult()
        {
            throw new NotSupportedException("I exist only so that you can find this method. I'm not for calling!");
        }
    }
}