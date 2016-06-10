using Shortener.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ninject;
using System.Web.Http.Results;
using Shortener.Models.Context.Models;
using Shortener.Models.ViewModels;

namespace Shortener.Controllers
{
    public class ShortLinkController : ApiController
    {
        private readonly IShortenerService _service;

        public ShortLinkController(IShortenerService service)
        {
            this._service = service;
        }

        public IEnumerable<UrlViewModel> Get()
        {
            return _service.GetAll();
        }
        
        public JsonResult<ShortUrl> Put([FromBody]string fullUrl)
        {
            return Json(_service.ShortenUrl(fullUrl));
        }

    }
}
