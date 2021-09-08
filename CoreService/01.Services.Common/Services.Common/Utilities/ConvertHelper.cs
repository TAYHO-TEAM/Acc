using Newtonsoft.Json.Linq;
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
        public static dynamic ConvertJProperty(JProperty input)
        {
            if (input.Value.Type.ToString() == "Integer")
            {
                try
                {
                    return Convert.ToInt32(input.Value);
                }
                catch
                {
                    return 0;
                }
            }
            else if (input.Value.Type.ToString() == "Boolean")
            {
                try
                {
                    return Convert.ToBoolean(input.Value);
                }
                catch
                {
                    return null;
                }
            }
            else if (input.Value.Type.ToString() == "Date")
            {
                try
                {
                    return Convert.ToDateTime(input.Value);
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                try
                {
                    return Convert.ToString(input.Value);
                }
                catch
                {
                    return null;
                }
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
        public static void DeleteNullProperties(object source)
        {
            foreach (var prop in source.GetType()
                                       .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                       .Where(p => !p.GetIndexParameters().Any())
                                       .Where(p => p.CanRead && p.CanWrite))
            {
                var value = prop.GetValue(source, null);
                if (value != null)
                {

                }
            }
        }
        public static List<int> SplitString2Int(string input, string charSplit)
        {
            string[] words = input.Split(charSplit);
            List<int> output = new List<int>();
            foreach (var item in words)
            {
                try
                {
                    output.Add(Convert.ToInt32(item));
                }
                catch
                {

                }
            }
            return output;
        }
    }
}
