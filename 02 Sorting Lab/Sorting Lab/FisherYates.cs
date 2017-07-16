using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Lab
{
    public static class FisherYates<T>
    {
        public static void Shuffle(T[] source)
        {
            Random rnd = new Random();

            for (int i = 0; i < source.Length; i++)
            {
                // Exchange array[i] with random element in array[i … n-1]

                int r = i + rnd.Next(0, source.Length - i);

                T temp = source[i];
                source[i] = source[r];
                source[r] = temp;
            }
        }
    }
}
