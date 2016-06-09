using Shortener.Models.Context.Models;
using Shortener.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortener.Models.Interfaces
{
    public interface IShortenerService : IDisposable
    {
        IList<UrlViewModel> GetAll();
        ShortUrl Get(string shortUrl);
        ShortUrl ShortenUrl(string fullUrl);
        void AddClick(string shortUrl);
    }
}
