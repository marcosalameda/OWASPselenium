using System;
using System.Collections.Generic;

namespace System.Collections.Generic
{
    public static class ListCompatibilityExtensions
    {
        public static bool TrueForAll(
            this IList<string> list,
            Func<string, bool> predicate)
        {
            foreach (var item in list)
            {
                if (!predicate(item))
                    return false;
            }
            return true;
        }
    }
}