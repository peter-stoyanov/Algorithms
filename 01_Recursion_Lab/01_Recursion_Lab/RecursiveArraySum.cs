using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RecursiveArraySum
{
    static void Main(string[] args)
    {
        var numbers = Console.ReadLine()
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int recursivelyCalculatedSum = Sum(numbers, 0);

        Console.WriteLine(recursivelyCalculatedSum);
    }

    private static int Sum(int[] numbers, int index)
    {
        //base case
        if (index == numbers.Length - 1)
        {
            return numbers[index];
        }

        //recursive call
        //Console.WriteLine($"call recursion with index = {index + 1}");
        //Console.WriteLine(string.Join(" ", numbers));
        return numbers[index] + Sum(numbers, index + 1);
    }
}
