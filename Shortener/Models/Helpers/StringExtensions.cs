using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortener.Models.Helpers
{
    public static class StringExtensions
    {
        private static readonly string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        public static string GetRandomString(int length = 6)
        {
            StringBuilder result = new StringBuilder();
            Random rand = new Random();
            while (0 < length--)
                result.Append(validCharacters[rand.Next(validCharacters.Length)]);
            return result.ToString();
        }
    }
}
