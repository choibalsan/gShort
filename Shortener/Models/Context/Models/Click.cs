using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortener.Models.Context.Models
{
    public class Click
    {
        public int ClickId { get; set; }
        public int ShortUrlId { get; set; }
        public DateTime Time { get; set; }
    }
}
