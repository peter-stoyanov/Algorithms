using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedLoops
{
    class CombinationsWithRepetitions
    {
        static void Main(string[] args)
        {
            var n = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray()[0];
            var k = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray()[0];

            GenerateCombinations(n, k);
        }

        private static void GenerateCombinations(int n, int k)
        {
            int[] combinations = new int[k];
            GenerateCombinations(combinations, n, 0, 1);
        }

        private static void GenerateCombinations(int[] combinations,int superSetLength, int currInd, int currStartInd)
        {
            //base case
            if (currInd == combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }
            
            //recursive calls
            for (int i = currStartInd; i < superSetLength; i++)
            {
                combinations[currInd] = i;
                if (i == 1)
                {
                    GenerateCombinations(combinations, superSetLength, currInd + 1, 1);
                }
                else
                {
                    GenerateCombinations(combinations, superSetLength, currInd + 1, currStartInd + 1);
                }
            }



        }
    }
}
