using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Web.Mvc;
using NUnit.Framework;
using Shortener.Controllers;
using Shortener.Tests.TestImplementations;
using Shortener.Models.Context.Models;
using System.Web;
using System.Web.Routing;

namespace Shortener.Tests.Controllers
{
    [TestFixture]
    public class HomeTest
    {
        HomeController controller;
        List<ShortUrl> testUrls = new List<ShortUrl>()
            {
                new ShortUrl() {Full="http://google.com/", Short="a12345",Time=DateTime.Now,Id=1 },
                new ShortUrl() {Full="http://reddit.com/", Short="b12345",Time=DateTime.Now,Id=2 },
                new ShortUrl() {Full="http://y0.ru/", Short="c12345",Time=DateTime.Now,Id=3 },
            };

        public HomeTest()
        {
            TestShortenerService service = new TestShortenerService(testUrls);
            controller = new HomeController(service);
            var request = new Mock<HttpRequestBase>();
            request.SetupGet(x => x.UserHostAddress).Returns("127.0.0.1");
            var context = new Mock<HttpContextBase>();
            context.SetupGet(x => x.Request).Returns(request.Object);
            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);
        }

        [TestCase("")]
        [TestCase("a12345")]
        [TestCase("b12345")]
        [TestCase("c12345")]
        [TestCase("ab12345")]
        public void Test_HomePage(string key)
        {
            ActionResult result = controller.Index(key);
            Assert.That(result, Is.Not.Null);
            ShortUrl chosenOne = testUrls.FirstOrDefault(u => u.Short == key);
            if (chosenOne != null)
            {
                RedirectResult redirect = result as RedirectResult;
                Assert.That(redirect, Is.Not.Null);
                Assert.That(redirect.Permanent, Is.EqualTo(true));
                Assert.That(redirect.Url, Is.EqualTo(chosenOne.Full));
            }
            else
            {
                Assert.That(result, Is.Not.Null);
            }
        }
    }
}
