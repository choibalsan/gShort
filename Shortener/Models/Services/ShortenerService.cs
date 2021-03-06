﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using Shortener.Models.Context;
using Shortener.Models.Context.Models;
using Shortener.Models.Interfaces;
using Shortener.Models.ViewModels;
using System.Text;
using Shortener.Models.Helpers;
using Shortener.Models.Exceptions;

namespace Shortener.Models.Services
{
    public class ShortenerService : IShortenerService
    {
        private ShortenerContext _context = new ShortenerContext();
        private BaseRepository<ShortUrl> _shortUrlRepository;
        private BaseRepository<Click> _clickRepository;

        protected BaseRepository<ShortUrl> ShortUrlRepository
        {
            get { return this._shortUrlRepository ?? (this._shortUrlRepository = new BaseRepository<ShortUrl>(_context)); }
        }
        protected BaseRepository<Click> ClickRepository
        {
            get { return this._clickRepository ?? (this._clickRepository = new BaseRepository<Click>(_context)); }
        }

        protected void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool CheckIfKeyExist(string key)
        {
            return _context.ShortUrls.Any(u => u.Short == key);
        }
        #region IShortenerService
        public IList<UrlViewModel> GetAll()
        {
            return ShortUrlRepository.Get()
                .Select(u => new UrlViewModel(u, u.Clicks.Count)).ToList();
        }

        public ShortUrl Get(string shortUrl)
        {
            return ShortUrlRepository.Get(u => u.Short.Equals(shortUrl, StringComparison.InvariantCulture)).FirstOrDefault();
        }

        public ShortUrl ShortenUrl(string fullUrl)
        {
            Uri myUri;
            if (Uri.TryCreate(fullUrl, UriKind.RelativeOrAbsolute, out myUri))
                throw new ShotrenerException("Invalid url!");

            ShortUrl newUrl = new ShortUrl() { Full = fullUrl, Time = DateTime.Now };
            string keyString = StringExtensions.GetRandomString();
            while (CheckIfKeyExist(keyString))
                keyString = StringExtensions.GetRandomString();
            newUrl.Short = keyString;
            ShortUrlRepository.Insert(newUrl);
            Save();
            return newUrl;
        }

        public void AddClick(int urlId, string ip)
        {
            ClickRepository.Insert(new Click() { ShortUrlId = urlId, Time = DateTime.Now, Ip = ip });
            Save();
        }

        #endregion
    }
}