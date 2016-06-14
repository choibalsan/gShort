using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortener.Models.Exceptions
{
    public class ShotrenerException : Exception
    {
        public ShotrenerException()
        {
        }

        public ShotrenerException(string message)
            : base(message)
        {
        }

        public ShotrenerException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
