using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary
{
    public static class ExtensionMethods
    {
        public static string ToCsv<T>(this IEnumerable<T> list)
        {
            return string.Join(",", list);
        }
    }
}
