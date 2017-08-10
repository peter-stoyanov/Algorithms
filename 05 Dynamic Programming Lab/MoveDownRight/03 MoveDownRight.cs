using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MoveDownRight
{
    struct Point
    {
        public Point(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
        public int Row { get; set; }
        public int Col { get; set; }
    }

    static void Main(string[] args)
    {
        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[m, n];

        //read matrix
        for (int i = 0; i < m; i++)
        {
            var rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int j = 0; j < rowData.Length; j++)
            {
                matrix[i, j] = rowData[j];
            }
        }

        // build the biggest sum to reach any cell in the matrix
        int[,] memo = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j == 0)
                {
                    memo[i, j] = matrix[i, j];
                    continue;
                }
                else if (i == 0)
                {
                    memo[i, j] = memo[i, j - 1] + matrix[i, j];
                    continue;
                }
                else if (j == 0)
                {
                    memo[i, j] = memo[i - 1, j] + matrix[i, j];
                    continue;
                }
                

                int fromTop = memo[i - 1, j];
                int fromLeft = memo[i, j - 1];

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

        #if DEBUG
        Console.WriteLine("best sums memo matrix:");

        for (int i = 0; i < memo.GetLength(0); i++)
        {
            for (int j = 0; j < memo.GetLength(1); j++)
            {
                Console.Write(memo[i, j] + " ");
            }
            Console.WriteLine();
        }
        #endif

        //keep optimal path
        var path = new List<Point>();

        //follow best sum values
        int row = m - 1;
        int col = n - 1;
        while (!(row == 0 && col == 0))
        {
            path.Add(new Point(row, col));

            int left = col == 0 ? 0 : memo[row, col - 1];
            int up = row == 0 ? 0 : memo[row - 1, col];

            if (up > left)
            {
                row -= 1;
            }
            else
            {
                col -= 1;
            }
        }

        path.Add(new Point(0, 0));

        path.Reverse();
        //print path
        for (int i = 0; i < path.Count; i++)
        {
            Console.Write(String.Format("[{0}, {1}] ", path[i].Row, path[i].Col));
        }
    }
}
