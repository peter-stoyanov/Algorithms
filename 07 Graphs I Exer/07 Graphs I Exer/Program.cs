using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();

    public static void Main()
    {
        var graph = ReadGraph();
        Console.WriteLine(string.Join(" ", graph.BFS()));
        foreach (var pair in pairs)
        {
            Console.WriteLine($"{{{pair.Item1}, {pair.Item2}}} -> {graph.FindShortestPath(pair.Item1, pair.Item2).Count}");
        }
    }



    private static Graph<int> ReadGraph()
    {
        int num_ver = int.Parse(Console.ReadLine());
        int num_pairs = int.Parse(Console.ReadLine());

        var graph = new Graph<int>();

        for (int i = 0; i < num_ver; i++)
        {
            var input_tokens = Console.ReadLine()
                .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            if (input_tokens.Count > 1)
            {
                graph.AddDirectedEdge(new GraphNode<int>(input_tokens[0]), new GraphNode<int>(input_tokens[1]), 1);
            }
            else
            {
                graph.AddNode(input_tokens[0]);
            }
        }

        for (int i = 0; i < num_pairs; i++)
        {
          var input_tokens = Console.ReadLine()
                .Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            pairs.Add(new Tuple<int, int>(input_tokens[0], input_tokens[0]));

        }

        return graph;
    }
}

