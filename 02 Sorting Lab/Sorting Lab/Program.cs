using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var testArray = Helpers.GenerateRandomArray(-100, 100, 1000);
            //var testArray = Helpers.GenerateSortedArray(0, 1000);

            Console.WriteLine(string.Join(", ", testArray));
            Console.WriteLine($"sorted: {Helpers.IsSorted(testArray)}");

            Stopwatch watch = new Stopwatch();
            watch.Start();

            //SelectionSort<int>.Sort(testArray);
            //BubbleSort<int>.Sort(testArray);
            //InsertionSort<int>.Sort(testArray);
            //FisherYates<int>.Shuffle(testArray);
            MergeSort<int>.Sort(ref testArray);

            watch.Stop();

            Console.WriteLine(string.Join(", ", testArray));
            Console.WriteLine($"sorted: {Helpers.IsSorted(testArray)}");
            Console.WriteLine($"Ticks: {watch.ElapsedTicks}");

            
        }
    }
}
