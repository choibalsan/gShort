using Shortener.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace Shortener.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShortenerService _service;

        public HomeController(IShortenerService service)
        {
            this._service = service;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}