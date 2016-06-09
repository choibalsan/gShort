using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortener.Models.Context.Models
{
    public class ShortUrl
    {
        public int ShortUrlId { get; set; }
        public string Full { get; set; }
        public string Short { get; set; }
        public DateTime Time { get; set; }
    }
}
