using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIndPathLabirinth
{
    class FIndPathLabirinth
    {
        static List<char> path = new List<char>();
        static char[,] matrix;

        static void Main(string[] args)
        {
            ReadLab();

            FIndPath(0, 0, 'S');
        }

        private static void ReadLab()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var row = Console.ReadLine().ToCharArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }

        private static void FIndPath(int row, int col, char direction)
        {
            if (!IsInBound(row, col))
            {
                return;
            }

            path.Add(direction);

            //base case
            if (IsExit(row, col))
            {
                PrintPath();
            }
            else if(!IsVisited(row, col) && IsFree(row, col))
            {
                Mark(row, col);
                FIndPath(row, col + 1, 'R');
                FIndPath(row, col - 1, 'L');
                FIndPath(row - 1, col, 'U');
                FIndPath(row + 1, col, 'D');
                Unmark(row, col);
            }

            path.RemoveAt(path.Count - 1);
        }

        private static void Unmark(int row, int col)
        {
            matrix[row, col] = '-';
        }

        private static void Mark(int row, int col)
        {
            matrix[row, col] = '+';
        }

        private static bool IsFree(int row, int col)
        {
            return matrix[row, col] != '*';
        }

        private static bool IsVisited(int row, int col)
        {
            return matrix[row, col] == '+';
        }

        private static void PrintPath()
        {
            Console.WriteLine(String.Join("", path.Skip(1)));
        }

        private static bool IsExit(int row, int col)
        {
            return matrix[row, col] == 'e'; 
        }

        private static bool IsInBound(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
