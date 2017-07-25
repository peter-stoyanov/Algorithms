using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorial_Algorithms
{
    public static class GeneralExtensions
    {
        public static T SwapWith<T>(this T current, ref T other)
        {
            T tmpOther = other;
            other = current;
            return tmpOther;
        }
    }

    class PermutationsWithoutRepetition
    {
        static void Main(string[] args)
        {
            var inputStrings = Console.ReadLine().Split().ToArray();
            //var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //GeneratePermutations(inputStrings);

            Permute(inputStrings);
        }

        // Algorithm with additional bool array
        private static void GeneratePermutations(string[] input)
        {
            bool[] used = new bool[input.Length];

            string[] permutation = new string[input.Length];

            GeneratePermutations(input, permutation, used, 0);
        }

        private static void GeneratePermutations(string[] input, string[] permutation, bool[] used, int index)
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

        //algorithm with no additionam memory req. and no add. arrays
        private static void Permute(string[] arr, int startIndex = 0)
        {
            if (startIndex >= arr.Length - 1)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = startIndex; i < arr.Length; i++)
                {
                    arr[startIndex] = arr[startIndex].SwapWith(ref arr[i]);
                    Permute(arr, startIndex + 1);
                    arr[i] = arr[i].SwapWith(ref arr[startIndex]);
                }
            }
        }

        private static void SwapIntegers(ref int i, ref int j)
        {
            if (i == j)
            {
                return;
            }

            i ^= j;
            j ^= i;
            i ^= j;
        }
    }
}
