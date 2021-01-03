using System;
using System.Collections.Generic;
using System.Text;

namespace Nutshell.Searching
{
    public static class Sequential
    {
        public static bool Exists(IEnumerable<int> values, int value)
        {
            foreach (var v in values)
            {
                if (v == value) return true;
            }
            return false;
        }
    }
}
