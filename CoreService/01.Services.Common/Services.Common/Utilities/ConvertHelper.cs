using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public static void CopyNonNullProperties(object source, object target)
        {
            // You could potentially relax this, e.g. making sure that the
            // target was a subtype of the source.
            if (source.GetType() != target.GetType())
            {
                throw new ArgumentException("Objects must be of the same type");
            }

            foreach (var prop in source.GetType()
                                       .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                       .Where(p => !p.GetIndexParameters().Any())
                                       .Where(p => p.CanRead && p.CanWrite))
            {
                var value = prop.GetValue(source, null);
                if (value != null)
                {
                    prop.SetValue(target, value, null);
                }
            }
        }
    }
}
