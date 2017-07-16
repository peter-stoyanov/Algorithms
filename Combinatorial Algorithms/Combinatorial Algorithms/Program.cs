using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorial_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();

            GeneratePermutations(input);

        }

        private static void GeneratePermutations(string[] input)
        {
            bool[] used = new bool[input.Length];

            string[] permutation = new string[input.Length];

            GeneratePermutations(input, permutation, used, 0);
        }

        private static void GeneratePermutations(int index)
        {
            //base case
            if (index >= input.Length)
            {
                Console.WriteLine(string.Join(" ", permutation));
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        permutation[index] = input[i];
                        GeneratePermutations(input, permutation, used, index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
