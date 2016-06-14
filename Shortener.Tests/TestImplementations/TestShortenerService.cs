using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using Shortener.Models.Context;
using Shortener.Models.Context.Models;
using Shortener.Models.Interfaces;
using Shortener.Models.ViewModels;
using System.Text;
using Shortener.Models.Helpers;

namespace Shortener.Tests.TestImplementations
{
    public class TestShortenerService : IShortenerService
    {
        private List<ShortUrl> Urls { get; set; }
        private List<Click> Clicks { get; set; }
        internal TestShortenerService(List<ShortUrl> urls = null, List<Click> clicks = null)
        {
            Urls = urls ?? new List<ShortUrl>();
            Clicks = clicks ?? new List<Click>();
        }
        #region IShortenerService
        public IList<UrlViewModel> GetAll()
        {
            return Urls.Select(u => new UrlViewModel(u, u.Clicks.Count)).ToList();
        }

        public ShortUrl Get(string shortUrl)
        {
            return Urls.FirstOrDefault(u => u.Short.Equals(shortUrl, StringComparison.InvariantCulture));
        }

        public ShortUrl ShortenUrl(string fullUrl)
        {
            ShortUrl newUrl = new ShortUrl() { Full = fullUrl, Time = DateTime.Now };
            string keyString = StringExtensions.GetRandomString();
            while (CheckIfKeyExist(keyString))
                keyString = StringExtensions.GetRandomString();
            newUrl.Short = keyString;
            Urls.Add(newUrl);
            return newUrl;
        }

        public void AddClick(int urlId, string ip)
        {
            Clicks.Add(new Click() { ShortUrlId = urlId, Time = DateTime.Now, Ip = ip });
        }

        #endregion

        public void Dispose()
        {
            Urls = null;
            Clicks = null;
        }
        private bool CheckIfKeyExist(string key)
        {
            return Urls.Any(u => u.Short == key);
        }
    }
}