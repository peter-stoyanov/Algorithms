using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    static List<int>[] graph;

    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    private static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
        }
        
        return graph;
    }

    private static void FindGraphConnectedComponents()
    {
        bool[] visited = new bool[graph.Length];
        int[] componentIds = new int[graph.Length];
        int count = 0;

        for (int i = 0; i < graph.Length; i++)
        {
            DFS(graph[i], i, visited, count, componentIds);
            count++;
        }
        var vertexesByComponents = componentIds
            .Select((v, i) => new { vertex = v, index = i })
            .GroupBy(node => node.vertex)
            .Select(group => new { componentId = group.Key, vertexes = group })
            .ToList();

        foreach (var componentGroup in vertexesByComponents)
        {
            Console.WriteLine($"Connected component: {String.Join(" ", componentGroup.vertexes.Select(v => v.index))}");
        }
    }

    private static void DFS(List<int> node, int index, bool[] visited, int count, int[] componentIds)
    {
        if (!visited[index])
        {
            visited[index] = true;
            componentIds[index] = count;
            foreach (var child in node)
            {
                DFS(graph.Where((g, i) => i == child).FirstOrDefault(), child, visited, count, componentIds);
            }
        }
    }
}
