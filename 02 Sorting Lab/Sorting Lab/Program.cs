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

            Console.WriteLine(string.Join(", ", testArray));
            Console.WriteLine($"sorted: {Helpers.IsSorted(testArray)}");

            Stopwatch watch = new Stopwatch();
            watch.Start();

            //SelectionSort<int>.Sort(testArray);
            BubbleSort<int>.Sort(testArray);

            watch.Stop();

            Console.WriteLine(string.Join(", ", testArray));
            Console.WriteLine($"sorted: {Helpers.IsSorted(testArray)}");
            Console.WriteLine($"Ticks: {watch.ElapsedTicks}");
        }
    }
}
