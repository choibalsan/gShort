using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using Shortener.Models.Context;
using Shortener.Models.Context.Models;
using Shortener.Models.Interfaces;
using Shortener.Models.ViewModels;

namespace Shortener.Models.Services
{
    public class ShortenerService : IShortenerService
    {
        public ShortenerService() { }
        private ShortenerContext context = new ShortenerContext();
        private BaseRepository<ShortUrl> departmentRepository;
        private BaseRepository<Click> courseRepository;

        public BaseRepository<ShortUrl> DepartmentRepository
        {
            get
            {
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new BaseRepository<ShortUrl>(context);
                }
                return departmentRepository;
            }
        }

        public BaseRepository<Click> CourseRepository
        {
            get
            {
                if (this.courseRepository == null)
                {
                    this.courseRepository = new BaseRepository<Click>(context);
                }
                return courseRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IList<UrlViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ShortUrl Get(string shortUrl)
        {
            throw new NotImplementedException();
        }

        public ShortUrl ShortenUrl(string fullUrl)
        {
            throw new NotImplementedException();
        }

        public void AddClick(string shortUrl)
        {
            throw new NotImplementedException();
        }
    }
}