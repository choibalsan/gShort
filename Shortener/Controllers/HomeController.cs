using Shortener.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Shortener.Models.Context.Models;

namespace Shortener.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShortenerService _service;

        public HomeController(IShortenerService service)
        {
            this._service = service;
        }

        public ActionResult Index(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return View();
            else
            {
                ShortUrl url = _service.Get(key);
                if (url != null)
                {
                    _service.AddClick(url.Id, Request.UserHostAddress);
                    return new RedirectResult(url.Full, true);
                }
                else
                    return View();
            }
        }
    }
}