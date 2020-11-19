using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nutshell.Sorting
{
    public static class Insertion
    {
        public static IEnumerable<int> Sort(IEnumerable<int> values)
        {
            var list = values.ToList();

            for (int i = 1; i < list.Count; i++)
            {
                Insert(list, i, list[i]);
            }
            return list;
        }

        private static void Insert(List<int> list, int pos, int value)
        {
            pos -= 1;
            while (pos >= 0 && list[pos] > value)
            {
                list[pos + 1] = list[pos];
                pos -= 1;
            }
            list[pos + 1] = value;
        }
    }
}
