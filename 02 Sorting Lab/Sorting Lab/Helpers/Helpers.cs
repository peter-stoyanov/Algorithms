using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Lab
{
    public static class Helpers
    {
        public static void Swap<T>(T[] collection, int from, int to)
        {
            T temp = collection[to];
            collection[to] = collection[from];
            collection[from] = temp;
        }

        public static bool Less(IComparable first, IComparable second)
        {
            return first.CompareTo(second) < 0;
        }

        public static bool IsSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }

            }
            return true;
        }

        public static int[] GenerateRandomArray(int lo, int hi, int size)
        {
            int[] arr = new int[size];

            Random randNum = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = randNum.Next(lo, hi);
            }

            return arr;
        }

        public static int[] GenerateSortedArray(int lo, int size)
        {
            int[] arr = new int[size];

            for (int i = lo; i < size; i++)
            {
                arr[i] = i;
            }

            return arr;
        }

        public static bool IndexInsideRange<T>(T[] array, int index)
        {
            return index >= 0 && index < array.Length - 1;
        }
    }
}
