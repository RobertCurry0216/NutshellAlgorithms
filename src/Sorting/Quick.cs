using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nutshell.Sorting
{
    public static class Quick
    {   
        public static IEnumerable<int> Sort(IEnumerable<int> values)
        {
            var lst = values.ToList();
            DoQuickSort(lst, 0, lst.Count-1);
            return lst;
        }

        private static void DoQuickSort(List<int> values, int low, int high)
        {
            // recursion exit clause
            if (low > high) return;

            // partition values
            int pi = Partition(values, low, high);

            // quicksort each side of the partition
            DoQuickSort(values, low, pi - 1);
            DoQuickSort(values, pi + 1, high);
        }

        private static int Partition(List<int> values, int low, int high)
        {
            var pivot = low;
            var pivotValue = values[high];
            int tmp;

            for (int i = low; i < high; i++)
            {
                if (values[i] < pivotValue)
                {
                    // swap values at i and pivot
                    tmp = values[i];
                    values[i] = values[pivot];
                    values[pivot] = tmp;

                    // inc pivot
                    pivot++;
                }
            }

            // move pivot value to the pivot index
            tmp = values[pivot];
            values[pivot] = values[high];
            values[high] = tmp;

            return pivot;
        }
    }
}
