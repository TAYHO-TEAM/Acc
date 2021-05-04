using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common.Utilities
{
    public static class ConvertHelper
    {
        public static int ConvertStringToInt(string input)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch
            {
                return 0;
            }
             
        }
    }
}
