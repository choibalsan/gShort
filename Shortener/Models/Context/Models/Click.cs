using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortener.Models.Context.Models
{
    public class Click
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Ip { get; set; }
        public int ShortUrlId { get; set; }
        public virtual ShortUrl ShortUrl { get; set; }
    }
}
