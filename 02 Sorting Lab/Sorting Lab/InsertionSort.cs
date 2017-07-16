using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Lab
{
    public static class InsertionSort<T> where T : IComparable
    {
        public static void Sort(T[] array)
        {
            //mark 1st as sorted
            //take next and find its place by swapping until:
            //- no more to the left
            //-left is smaller than it
            //move like this first to last unsorted
            //unsorted area shrinks each time

            //CPU ticks for 1000 elements ~= 50_000 with strange peaks to 90_000

            //great for almost sorted arrays

            for (int lastSortedInd = 0; lastSortedInd < array.Length - 1; lastSortedInd++)
            {
                int prevInd = lastSortedInd;
                int firstUnsortedInd = lastSortedInd + 1;

                T firstUnsorted = array[firstUnsortedInd];
                T prev = array[prevInd];

                while (Helpers.Less(firstUnsorted, prev) && prevInd >= 0)
                {
                    Helpers.Swap(array, firstUnsortedInd, prevInd);

                    prevInd--;
                    firstUnsortedInd--;

                    if (!Helpers.IndexInsideRange(array, prevInd)
                        || !Helpers.IndexInsideRange(array, firstUnsortedInd))
                    {
                        break;
                    }

                    firstUnsorted = array[firstUnsortedInd];
                    prev = array[prevInd];
                }
            }
        }
    }
}
