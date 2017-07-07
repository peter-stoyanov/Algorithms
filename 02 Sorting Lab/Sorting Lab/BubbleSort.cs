using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Lab
{
    public static class BubbleSort<T> where T : IComparable
    {
        public static void Sort(T[] array)
        {
            //Swaps each two and pull the biggest to the right end

            //CPU ticks for 1000 elements ~= 50_000

            bool swapped;
            int upperBoundOffset = 0;
            do
            {
                swapped = false; 

                for (int currInd = 0; currInd < array.Length - 1 - upperBoundOffset; currInd++)
                {
                    if (!Helpers.Less(array[currInd], array[currInd + 1]))
                    {
                        Helpers.Swap(array, currInd, currInd + 1);
                        swapped = true;
                    }
                }

                upperBoundOffset++;

            } while (swapped); //start new traversing if anything was swapped the last time
        }
    }
}
