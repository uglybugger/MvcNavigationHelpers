using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using MvcNavigationHelpers;
using SampleMvcApp.Models;

namespace SampleMvcApp.Controllers
{
    public class HomeController : AsyncController
    {
        public ActionResult AwfulIndex()
        {
            // NOTE: If you do this in production code, you are a Bad Person. You should take a dependency on
            // an IClock instead. And if you use DateTime rather than DateTimeOffset, you deserve everything bad
            // that happens to you :)
            var todayIsThursday = DateTimeOffset.Now.DayOfWeek == DayOfWeek.Thursday;

            return todayIsThursday
                ? RedirectToAction("ThursdayLandingPage", new {someAnswer = 42})
                : RedirectToAction("DefaultLandingPage", new { someQuestion = "What is the answer to life, the universe and everything?" });
        }

     
        public RedirectResult Index()
        {
            // NOTE: If you do this in production code, you are a Bad Person. You should take a dependency on
            // an IClock instead. And if you use DateTime rather than DateTimeOffset, you deserve everything bad
            // that happens to you :)
            var todayIsThursday = DateTimeOffset.Now.DayOfWeek == DayOfWeek.Thursday;

            return todayIsThursday
                ? Redirect(Url.UrlFor<HomeController>(c => c.ThursdayLandingPage(42)))
                : Redirect(Url.UrlFor<HomeController>(c => c.DefaultLandingPage("What is the answer to life, the universe and everything?")));
        }

        public ActionResult ThursdayLandingPage(int someAnswer)
        {
            var model = new ThursdayLandingPageViewModel
                        {
                            TheAnswer = someAnswer,
                        };

            return View(model);
        }

        public ActionResult DefaultLandingPage(string someQuestion)
        {
            var model = new DefaultLandingPageViewModel
                        {
                            TheQuestion = someQuestion,
                        };

            return View(model);
        }

        public async Task<RedirectResult> IndexAsync()
        {
            return Redirect(Url.UrlFor<HomeController, RedirectResult>(c => c.OneHop()));
        }

        public async Task<RedirectResult> OneHop()
        {
            return Redirect(Url.UrlFor<HomeController, ActionResult>(c => c.TwoHop()));
        }

        public async Task<ActionResult> TwoHop()
        {
            return View();
        }
    }
}