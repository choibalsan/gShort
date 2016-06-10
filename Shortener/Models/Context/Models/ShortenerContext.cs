using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Shortener.Models.Context.Models
{
    public class ShortenerContext : DbContext
    {
        public ShortenerContext()
            : base("DbConnection")
        { }

        public DbSet<ShortUrl> ShortUrls { get; set; }
        public DbSet<Click> Clicks { get; set; }
    }
}