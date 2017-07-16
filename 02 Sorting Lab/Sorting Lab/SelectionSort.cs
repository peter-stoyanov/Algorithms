using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Lab
{
    public static class SelectionSort<T> where  T : IComparable
    {
        public static void Sort(T[] array)
        {
            //Swaps the first element with the min element on the right unsorted part
            //pulls the sorted elements to the left, can be run a few times when a few 
            //of the first sorted results are neeeded, not the whole collection

            //CPU ticks for 1000 elements = 40_000 - 50_000

            for (int leftBound = 0; leftBound < array.Length; leftBound++)
            {
                int minInd = leftBound;
                for (int currInd = leftBound + 1; currInd < array.Length; currInd++)
                {
                    if (Helpers.Less(array[currInd], array[minInd]))
                    {
                        minInd = currInd;
                    }
                }

                Helpers.Swap(array, minInd, leftBound);
            }
        }
    }
}
