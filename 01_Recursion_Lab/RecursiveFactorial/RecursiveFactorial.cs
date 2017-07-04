using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RecursiveFactorial
{
    static void Main(string[] args)
    {
        var number = int.Parse(Console.ReadLine());

        int factorial = CalcFactorial(number);

        Console.WriteLine(factorial);
    }

    private static int CalcFactorial(int number)
    {
        //base case
        if (number == 1)
        {
            return 1;
        }

        //recursive call
        //Console.WriteLine($"call recursion on number = {number}");
        return number * CalcFactorial(number - 1);
    }
}
