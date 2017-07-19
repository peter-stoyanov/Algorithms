using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedLoops
{
    class NestedLoops
    {
        static void Main(string[] args)
        {
            //of n nested loops from 1 to n which prints the values of all its iteration variables 
            //at any given time on a single line

            var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray()[0];

            PrintIterationVars(input);
        }

        private static void PrintIterationVars(int n)
        {
            int[] combinations = new int[n];
            PrintIterationVars(combinations, 0);
        }

        private static void PrintIterationVars(int[] array, int currInd)
        {
            //base case
            if (currInd == array.Length)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            //recursive calls
            for (int i = 0; i < array.Length; i++)
            {
                array[currInd] = i + 1;
                PrintIterationVars(array, currInd + 1);
            }

        }
    }
}
