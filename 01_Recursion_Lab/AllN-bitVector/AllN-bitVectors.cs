using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AllNbitVectors
{
    static void Main(string[] args)
    {
        var number = int.Parse(Console.ReadLine());

        var vectorArray = new int[number];
        GenerateVector(0, vectorArray);

    }

    private static void GenerateVector(int index, int[] array)
    {
        //Console.WriteLine($"method was called with index = {index} ==== " + string.Join(" ", array));

        //base case
        if (index >= array.Length)
        {
            Console.WriteLine(string.Join("", array));
            return;
        }

        array[index] = 0;
        GenerateVector(index + 1, array);

        array[index] = 1;
        GenerateVector(index + 1, array);

    }
}
