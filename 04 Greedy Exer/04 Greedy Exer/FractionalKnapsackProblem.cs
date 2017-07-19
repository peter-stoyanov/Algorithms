using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Greedy_Exer
{
    public class Item : IComparable<Item>
    {
        public Item(decimal price, int weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public decimal ValuePerUnit
        {
            get { return this.Price / this.Weight; }
        }

        public int CompareTo(Item other)
        {
            return this.ValuePerUnit.CompareTo(other.ValuePerUnit);
        }

        public override string ToString()
        {
            return string.Format("price: {0}; weight: {1}", this.Price, this.Weight);
        }
    }

    public class FractionalKnapsackProblem
    {
        public static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine().Split(':')[1]);
            int countOfItems = int.Parse(Console.ReadLine().Split(':')[1]);

            List<Item> items = new List<Item>();

            ReadInput(items, countOfItems);

            var sortedItems = items.OrderByDescending(i => i).ToList();
            int currentCapacity = 0;
            decimal totalPrice = 0;
            int index = 0;

            while (index < sortedItems.Count && currentCapacity != capacity)
            {
                var current = sortedItems[index];
                if (current.Weight + currentCapacity < capacity)
                {
                    currentCapacity += current.Weight;
                    totalPrice += current.Price;
                    Console.WriteLine("Take 100% of item with price {0:f2} and weight {1:f2}", current.Price, current.Weight);
                }
                else
                {
                    int needed = capacity - currentCapacity;
                    decimal persentage = (decimal)needed / current.Weight;
                    decimal price = persentage * current.Price;
                    totalPrice += price;
                    currentCapacity += needed;
                    Console.WriteLine("Take {0:f2}% of item with price {1:f2} and weight {2:f2}", persentage * 100, current.Price, current.Weight);
                }

                index++;
            }

            Console.WriteLine("Total price: {0:f2}", totalPrice);
        }

        private static void ReadInput(List<Item> items, int countOfItems)
        {
            for (int i = 0; i < countOfItems; i++)
            {
                string[] data = Console.ReadLine().Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                Item currentItem = new Item(decimal.Parse(data[0]), int.Parse(data[1]));

                items.Add(currentItem);
            }
        }
    }
}
