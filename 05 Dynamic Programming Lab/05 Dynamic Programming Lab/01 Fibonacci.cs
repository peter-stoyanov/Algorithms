using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StartUp
{
    private static Dictionary<int, int> memo = new Dictionary<int, int>();

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        //1 - define subproblems - # of subproblems
        //2 - guess part of solution = # of 
        //3 - recurrence - time per subproblem
        //4 - recurse + memoize OR bottom-up (check acyclic topographical order)
        //5 - solve original problem (either its the last sub-solution or combination of sub-solutions)

        int fib = Fibonacci(n);

        Console.WriteLine(fib);
    }

    private static int Fibonacci(int n)
    {
        //base case
        if (n == 1 || n == 2)
        {
            return 1;
        }

        //pre-actions
        if (memo.ContainsKey(n))
        {
            return memo[n];
        }

        //recursive call

        int fib = Fibonacci(n - 1) + Fibonacci(n - 2);

        memo.Add(n, fib);

        return fib;
    }
}
