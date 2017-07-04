using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RecursiveDrawing
{
    static void Main(string[] args)
    {
        var number = int.Parse(Console.ReadLine());

        Draw(number);

    }

    private static void Draw(int number)
    {
        //base case
        if (number == 0)
        {
            return;
        }
        
        //pre-actions
        Console.WriteLine(new string('*', number));

        //recursive call
        Draw(number - 1);

        //post-actions
        Console.WriteLine(new string('#', number));

    }
}
