using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nutshell.Sorting
{
    public static class Merge
    {
        public static IEnumerable<int> Sort (IEnumerable<int> values)
        {
            var copy = values.ToList();
            var sorted = values.ToList();
            MergeSort(ref copy, ref sorted, 0, sorted.Count());

            return sorted;
        }

        private static void MergeSort(ref List<int> arr, ref List<int> result, int start, int end)
        {
            // recursion escape cases
            if (end - start < 2) return;
            if (end - start == 2 && result[start] > result[start + 1])
            {
                var tmp = result[start];
                result[start] = result[start + 1];
                result[start + 1] = tmp;
                return;
            }

            //split array in half and sort
            var mid = (end + start) / 2;
            MergeSort(ref result, ref arr, start, mid);
            MergeSort(ref result, ref arr, mid, end);

            // Combine sorted lists
            var i = start;
            var j = mid;
            var idx = start;
            while (idx < end)
            {
                if (j >= end || (i < mid && arr[i] < arr[j]))
                {
                    result[idx] = arr[i];
                    i++;
                }
                else
                {
                    result[idx] = arr[j];
                    j++;
                }
                idx++;
            }
        }
    }
}
