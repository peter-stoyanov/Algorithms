using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MoveDownRight
{
    static void Main(string[] args)
    {
        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[m,n];

        //read matrix
        for (int i = 0; i < m; i++)
        {
            var rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int j = 0; j < rowData.Length; j++)
            {
                matrix[i, j] = rowData[j];
            }
        }

        //keep previous results and reuse them
        int[,] memo = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                //base case
                if (i == 0 && j == 0)
                {
                    memo[i, j] = matrix[i, j];
                    continue;
                }

                int fromTop = i == 0 ? 0 : memo[i - 1, j];
                int fromLeft = j == 0 ? 0 : memo[i, j - 1];

                if (fromTop > fromLeft)
                {
                    memo[i, j] = matrix[i, j] + fromTop;
                }
                else
                {
                    memo[i, j] = matrix[i, j] + fromLeft;
                }
            }
        }
        
        //keep optimal path
        var path = new List<int>();

        //follow best sum values
        int row = 0;
        int col = 0;
        while (!(row == m - 1 && col == n - 1))
        {
            path.Add(row);
            path.Add(col);

            int toTheRight = col == n - 1 ? 0 : memo[row, col + 1];
            int toTheLeft = row == m - 1 ? 0 : memo[row + 1, col];

            if (row == m - 1)
            {
                col += 1;
            }
            else if (col == n - 1)
            {
                row += 1;
            }
            else if (toTheRight > toTheLeft)
            {
                col += 1;
            }
            else
            {
                row += 1;
            }
        }

        path.Add(m - 1);
        path.Add(n - 1);

        //print path
        for (int i = 0; i < path.Count - 1; i = i + 2)
        {
            Console.Write(String.Format("[{0}, {1}] ", path[i], path[i + 1]));
        }
    }
}
