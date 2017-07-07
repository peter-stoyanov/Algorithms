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

            //CPU ticks for 1000 elements ~= 50_000

            for (int lastSortedInd = 0; lastSortedInd < array.Length - 1; lastSortedInd++)
            {
                T firstUnsorted = array[lastSortedInd + 1];

                int sortedEndOffset = 0;
                T prev = array[lastSortedInd - sortedEndOffset];
                while (Helpers.Less(firstUnsorted, prev) || sortedEndOffset == lastSortedInd)
                {
                    Helpers.Swap(array, );

                    sortedEndOffset++;
                    prev = array[lastSortedInd - sortedEndOffset];
                }
            }




            if (!Helpers.Less(array[currInd], array[currInd + 1]))
            {
                Helpers.Swap(array, currInd, currInd + 1);
            }

        }
    }
}
