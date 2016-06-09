using Shortener.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ninject;

namespace Shortener.Controllers
{
    public class ShortLinkController : ApiController
    {
        private readonly IShortenerService _service;

        public ShortLinkController(IShortenerService service)
        {
            this._service = service;
        }

    }
}
