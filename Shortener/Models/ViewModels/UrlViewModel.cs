using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortener.Models.ViewModels
{
    public class UrlViewModel
    {
        public int ShortUrlId { get; set; }
        public string Full { get; set; }
        public string Short { get; set; }
        public DateTime Time { get; set; }
        public int ClicksCount { get; set; }
    }
}
