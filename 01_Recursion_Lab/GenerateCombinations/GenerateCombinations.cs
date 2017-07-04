using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GenerateCombinations
{
    static void Main(string[] args)
    {
        //1 2 3 4
        //2

        var numbersToChooseFrom = Console.ReadLine()
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var combinationsLength = int.Parse(Console.ReadLine());

        int[] combinations = new int[combinationsLength];

        GenCombs(0, 0, numbersToChooseFrom, combinations);

    }

    private static void GenCombs(int index, int border, int[] source, int[] combinations)
    {
        //Console.WriteLine($"method was called with index = {index} ==== " + string.Join(" ", array));

        //base case
        if (index >= combinations.Length)
        {
            Console.WriteLine(string.Join(" ", combinations));
            return;
        }

        for (int i = border; i < source.Length; i++)
        {
            combinations[index] = source[i];
            GenCombs(index + 1, i + 1, source, combinations);
        }


    }
}
