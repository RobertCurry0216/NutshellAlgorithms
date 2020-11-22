using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nutshell.Sorting
{
    public static class Bucket
    {
        public static IEnumerable<int> Sort(IEnumerable<int> values, int min, int max)
        {
            // create buckets
            var nBuckets = max - min + 1;
            var buckets = new List<List<int>>();
            for (int i = 0; i < nBuckets; i++)
            {
                buckets.Add(new List<int>());
            }

            // add values to the buckets
            foreach (var value in values)
            {
                var key = Hash(value, min);
                buckets[key].Add(value);
            }

            // join buckets into a single list
            var returnValues = new List<int>();
            foreach (var bucket in buckets)
            {
                returnValues.AddRange(bucket);
            }

            return returnValues;
        }

        private static int Hash(int value, int min)
        {
            return value - min;
        }
    }
}
