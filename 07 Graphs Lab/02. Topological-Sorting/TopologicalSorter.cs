using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSort()
    {
        //preprocess -> predecessors by vertex
        var predecessorsCount = new Dictionary<string, int>();

        foreach (var sourceTargetPair in graph)
        {
            if (!predecessorsCount.ContainsKey(sourceTargetPair.Key))
            {
                predecessorsCount[sourceTargetPair.Key] = 0;
            }

            foreach (var target in sourceTargetPair.Value)
            {
                if (predecessorsCount.ContainsKey(target))
                {
                    predecessorsCount[target]++;
                }
                else
                {
                    predecessorsCount.Add(target, 1);
                }
            }
        }
        //find V with no parents
        var sortedGraph = new List<string>();

        while (true)
        {
            var nodeWithoutSource = predecessorsCount.Keys
                .Where(x => predecessorsCount[x] == 0).FirstOrDefault();

            if (nodeWithoutSource != null)
            {
                //adjust predecessors count on children
                foreach (var orphan in graph[nodeWithoutSource])
                {
                    predecessorsCount[orphan]--;
                }

                //remove it
                graph.Remove(nodeWithoutSource);
                predecessorsCount.Remove(nodeWithoutSource);

                //add removed node to sort order
                sortedGraph.Add(nodeWithoutSource);
            }
            else
            {
                break;
            }
        }

        //if in the end stil exists V's in graph - > exception for cycle
        if (graph.Any())
        {
            throw new InvalidOperationException("Graph has cycle.");
        }

        return sortedGraph;
    }
}
