using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_Exer
{
    class ReverseArray
    {
        static void Main(string[] args)
        {
            // 1 2 3 4 5 6
            // 6 5 4 3 2 1
            var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            var result = ReverseRecursive(input);

            Console.WriteLine(String.Join(" ", result));
        }

        private static int[] ReverseRecursive(int[] array)
        {
            return ReverseRecursive(array, 0);

        }

        private static int[] ReverseRecursive(int[] array, int index)
        {
            //base case
            if (index == array.Length / 2)
            {
                return array;
            }

            Swap(array, index, array.Length - index - 1);

            //recursive call
            return ReverseRecursive(array, ++index);
        }

        public static void Swap(int[] array, int from, int to)
        {
            int temp = array[to];
            array[to] = array[from];
            array[from] = temp;
        }
    }
}
