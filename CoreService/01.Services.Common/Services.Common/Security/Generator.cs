using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common.Security
{
    public static class GenerateHelper
    {
        public static string GenCode(int length = 0, bool Upper = false, bool differenceUpper = false, bool onlyNumber = false, bool onlyLatter = false)
        {
            const string _number = "0123456789";
            const string _lower = "abcdefghijklmnopqrstuvwxyz";
            const string _upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string pool = onlyNumber ? _number :(onlyLatter?(differenceUpper? _upper+_lower:(Upper? _upper: _lower)): (differenceUpper ? _upper + _lower : (Upper ? _upper : _lower))+_number) ;
            var builder = new StringBuilder();
            Random rnd = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = pool[rnd.Next(0, pool.Length)];
                builder.Append(c);
            }
            return builder.ToString();
        }
    }
}
