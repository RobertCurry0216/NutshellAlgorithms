using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nutshell.Sorting
{
    public static class Heap
    {
        public static IEnumerable<int> Sort(IEnumerable<int> values)
        {
            var lst = values.ToList();

            BuildHeap(lst);

            for (int i = lst.Count - 1; i > 0; i--)
            {
                //swap first and last elements
                var tmp = lst[0];
                lst[0] = lst[i];
                lst[i] = tmp;

                //run heapify on the reduced list
                heapify(lst, 0, i);
            }

            return lst;
        }

        // Makes sure the head of the node is the largest value
        // and recursively call itself if the head wasn't already the biggest value
        private static void heapify(List<int> lst, int idx, int max)
        {
            var largest = idx;
            var left = (idx * 2) + 1;
            var right = (idx * 2) + 2;

            // find the highest value out of
            // idx, left, and right
            if (left < max && lst[left] > lst[largest])
            {
                largest = left;
            }
            if (right < max && lst[right] > lst[largest])
            {
                largest = right;
            }

            // move largest value to the head of the node
            if (largest != idx)
            {
                var tmp = lst[idx];
                lst[idx] = lst[largest];
                lst[largest] = tmp;

                // recursively call heapify back down the tree
                heapify(lst, largest, max);
            }
        }

        // Builds the initial heap
        // starts from the second bottom row of the tree
        // and works it's way up to make sure the 
        // highst value is at the top of the tree
        private static void BuildHeap(List<int> lst)
        {
            var n = lst.Count;
            for (int i = (lst.Count / 2) - 1; i >= 0; i--)
            {
                heapify(lst, i, n);
            }
        }
    }
}
