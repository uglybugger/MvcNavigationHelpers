# MvcNavigationHelpers

This is the way navigation is done in ASP.NET MVC applications:

    public ActionResult AwfulIndex()
    {
        // NOTE: If you do this in production code, you are a Bad Person. You should take a dependency on
        // an IClock instead. And if you use DateTime rather than DateTimeOffset, you deserve everything bad
        // that happens to you :)
        var todayIsThursday = DateTimeOffset.Now.DayOfWeek == DayOfWeek.Thursday;

        return todayIsThursday
                   ? RedirectToAction("ThursdayLandingPage", new { someAnswer = 42})
                   : RedirectToAction("DefaultLandingPage", new { someQuestion = "What is the answer to life, the universe and everything?"});
    }

This way is yucky. Magic strings are great, and all, but I like my code to keep working after I've shipped it and want to rename something.

I like this way better:

    public ActionResult Index()
    {
        // NOTE: If you do this in production code, you are a Bad Person. You should take a dependency on
        // an IClock instead. And if you use DateTime rather than DateTimeOffset, you deserve everything bad
        // that happens to you :)
        var todayIsThursday = DateTimeOffset.Now.DayOfWeek == DayOfWeek.Thursday;

        return todayIsThursday
                   ? Redirect(Url.UrlFor<HomeController>(c => c.ThursdayLandingPage(42)))
                   : Redirect(Url.UrlFor<HomeController>(c => c.DefaultLandingPage("What is the answer to life, the universe and everything?")));
    }

What's different between these two?

The awful one:

* has no strong typing;
* will allow me to specify invalid routing values;
* leads to innumerable runtime errors after some bright spark decides to rename a controller, method or parameter;
* isn't refactoring-friendly.

The nice one:

* is strongly-typed;
* will generate compile-time errors if you miss a required parameter;
* simply doesn't let me call parameters the wrong thing;
* pulls route values directly out of your expression;
* is friendly to even the most primitive refactoring tools (Here's lookin' at you, Visual Studio...)

# How do I get it?

    Install-Package MvcNavigationHelpers

Job done.

I'd probably add a convention test or two to make sure that nobody's calling any of the silly magic-string overloads any more, especially if you have new people playing in your sandpit on occasion - they'll probably think they're doing a good thing by using explicit string for controller and action names. **You can automate this. It has value and it's cheap to do, so you *should* automate this.**

# FAQ

## Haven't you heard of MvcContrib?
Nope. Never heard of it. I came down in the last shower, me.

If you want the full feature set of MvcContrib, go right ahead. I tend to avoid pulling it into my own projects as it comes with a bunch of baggage I don't really want around, but that's just me. YMMV.

## This is, like, two classes. Why did you NuGet something that small?
Because I keep using it in different projects and want it available to me.

If you like it, that's a bonus :)

## Don't you know that ReSharper will refactor controller action names for you?
You mileage will *definitely* vary on this one. I love ReSharper - and anyone who doesn't use it is stealing from themselves and their employer - but magic strings are magic strings. I don't like them, and neither should you.

Try a ^R^R on a method named "Index" sometime and let me know how that goes for you :)
