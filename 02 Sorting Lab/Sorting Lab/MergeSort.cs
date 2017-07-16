using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Lab
{
    public static class MergeSort<T> where T : IComparable
    {
        public static void Sort(ref T[] array)
        {
            //CPU ticks for 1000 elements ~= 15_000

            array = RecursiveMergeSort(ref array);
        }

        private static T[] RecursiveMergeSort(ref T[] array)
        {
            //base case
            if (array.Length == 1)
            {
                return array;
            }

            //pre-actions
            T[] leftHalf = array.Take(array.Length / 2).ToArray();
            T[] rightHalf = array.Skip(array.Length / 2).ToArray();

            //Console.WriteLine("--> left half passed : " + string.Join(", ", leftHalf));
            //Console.WriteLine("--> right half passed : " + string.Join(", ", rightHalf));

            //recursive calls
            T[] leftSortedHalf = RecursiveMergeSort(ref leftHalf);
            T[] rightSortedHalf = RecursiveMergeSort(ref rightHalf);

            //Console.WriteLine("   <-- left half returned : " + string.Join(", ", leftSortedHalf));
            //Console.WriteLine("   <-- right half returned : " + string.Join(", ", rightSortedHalf));

            //post-actions - MERGE
            int leftPointer = 0;
            int rightPointer = 0;
            int mergedPointer = 0;

            T[] mergedArray = new T[leftSortedHalf.Length + rightSortedHalf.Length];

            while (mergedPointer < leftSortedHalf.Length + rightSortedHalf.Length)
            {
                if (leftPointer == leftSortedHalf.Length)
                {
                    mergedArray[mergedPointer] = rightSortedHalf[rightPointer];
                    rightPointer++;
                    mergedPointer++;
                }
                else if (rightPointer == rightSortedHalf.Length)
                {
                    mergedArray[mergedPointer] = leftSortedHalf[leftPointer];
                    leftPointer++;
                    mergedPointer++;
                }
                else
                {
                    if (leftSortedHalf[leftPointer].CompareTo(rightSortedHalf[rightPointer]) < 0)
                    {
                        mergedArray[mergedPointer] = leftSortedHalf[leftPointer];
                        leftPointer++;
                        mergedPointer++;
                    }
                    else if (leftSortedHalf[leftPointer].CompareTo(rightSortedHalf[rightPointer]) > 0)
                    {
                        mergedArray[mergedPointer] = rightSortedHalf[rightPointer];
                        rightPointer++;
                        mergedPointer++;
                    }
                    else
                    {
                        mergedArray[mergedPointer] = leftSortedHalf[leftPointer];
                        mergedArray[mergedPointer + 1] = rightSortedHalf[rightPointer];
                        leftPointer++;
                        rightPointer++;
                        mergedPointer += 2;
                    }
                }

            }
            return mergedArray;
        }
    }
}
