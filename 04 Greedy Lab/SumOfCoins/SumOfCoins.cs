namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var selectedCoins = new Dictionary<int, int>();

            //sort so its easy to take the biggest available coin
            var availableCoins = coins.OrderBy(c => -c).ToList();

            int proposedCoin = 0;
            while (availableCoins.Count > 0)
            {
                proposedCoin = availableCoins.FirstOrDefault();

                if (targetSum >= proposedCoin)
                {
                    //add to selected coins
                    if (selectedCoins.ContainsKey(proposedCoin))
                    {
                        selectedCoins[proposedCoin]++;
                    }
                    else
                    {
                        selectedCoins.Add(proposedCoin, 1);
                    }

                    targetSum -= proposedCoin;
                }
                else
                {
                    //remove from available coins
                    availableCoins.Remove(proposedCoin);
                }
            }

            if (targetSum > 0)
            {
                throw new InvalidOperationException("Greedy algorithm can not produce desired sum with available coins.");
            }

            return selectedCoins;
        }
    }
}