using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NodeList<T> : Collection<GraphNode<T>> where T : IComparable 
{
    public NodeList() : base() { }

    public NodeList(int initialSize)
    {
        // Add the specified number of items
        for (int i = 0; i < initialSize; i++)
            base.Items.Add(default(GraphNode<T>));
    }

    public GraphNode<T> FindByValue(T value)
    {
        // search the list for the value
        foreach (GraphNode<T> node in Items)
            if (node.Value.Equals(value))
                return node;

        // if we reached here, we didn't find a matching node
        return null;
    }
}

public class GraphNode<T> where T : IComparable
{
    // Private member-variables
    private T data;
    private NodeList<T> neighbors = null;
    private List<int> costs;

    public GraphNode() { }
    public GraphNode(T data) : this(data, null) { }
    public GraphNode(T data, NodeList<T> neighbors) : this(data, neighbors, null) { }
    public GraphNode(T data, NodeList<T> neighbors, List<int> costs)
    {
        this.data = data;
        this.neighbors = neighbors ?? new NodeList<T>();
        this.costs = costs ?? new List<int>();
    }

    public T Value
    {
        get => data;
        set => data = value;
    }

    public NodeList<T> Neighbors
    {
        get => neighbors;
        set => neighbors = value;
    }

    public List<int> Costs
    {
        get => costs;
        set => costs = value;
    }
}

public class Graph<T> : IEnumerable<T> where T : IComparable
{
    private NodeList<T> nodes;

    public Graph() : this(null) { }
    public Graph(NodeList<T> nodeSet)
    {
        if (nodeSet == null)
            this.nodes = new NodeList<T>();
        else
            this.nodes = nodeSet;
    }

    public void AddNode(GraphNode<T> node)
    {
        // adds a node to the graph
        nodes.Add(node);
    }

    public void AddNode(T value)
    {
        // adds a node to the graph
        if (nodes.FindByValue(value) == null)
            nodes.Add(new GraphNode<T>(value));
    }

    public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost = 1)
    {
        AddDirectedEdgeWithChecks(from, to, cost);
    }

    public void AddDirectedEdge(T from, T to, int cost = 1)
    {
        var fromNode = new GraphNode<T>(from);
        var toNode = new GraphNode<T>(to);

        AddDirectedEdgeWithChecks(fromNode, toNode, cost);
    }

    private void AddDirectedEdgeWithChecks(GraphNode<T> from, GraphNode<T> to, int cost = 1)
    {
        if (nodes.FindByValue(from.Value) == null) { AddNode(from); }
        if (nodes.FindByValue(to.Value) == null) { AddNode(to); }

        from.Neighbors.Add(to);
        from.Costs.Add(cost);
    }

    public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost = 1)
    {
        AddUndirectedEdgeWithChecks(from, to, cost);
    }

    public void AddUndirectedEdge(T from, T to, int cost = 1)
    {
        var fromNode = new GraphNode<T>(from);
        var toNode = new GraphNode<T>(to);

        AddUndirectedEdgeWithChecks(fromNode, toNode, cost);
    }

    private void AddUndirectedEdgeWithChecks(GraphNode<T> from, GraphNode<T> to, int cost = 1)
    {
        if (nodes.FindByValue(from.Value) == null) { AddNode(from); }
        if (nodes.FindByValue(to.Value) == null) { AddNode(to); }

        from.Neighbors.Add(to);
        from.Costs.Add(cost);

        to.Neighbors.Add(from);
        to.Costs.Add(cost);
    }

    public bool Contains(T value)
    {
        return nodes.FindByValue(value) != null;
    }

    public bool Remove(T value)
    {
        // first remove the node from the nodeset
        GraphNode<T> nodeToRemove = nodes.FindByValue(value);
        if (nodeToRemove == null)
            // node wasn't found
            return false;

        // otherwise, the node was found
        nodes.Remove(nodeToRemove);

        // enumerate through each node in the nodeSet, removing edges to this node
        foreach (GraphNode<T> gnode in nodes)
        {
            int index = gnode.Neighbors.IndexOf(nodeToRemove);
            if (index != -1)
            {
                // remove the reference to the node and associated cost
                gnode.Neighbors.RemoveAt(index);
                gnode.Costs.RemoveAt(index);
            }
        }

        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var node in this.nodes)
        {
            yield return node.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public NodeList<T> Nodes
    {
        get
        {
            return nodes;
        }
    }

    public int Count
    {
        get { return nodes.Count; }
    }

    public HashSet<T> BFS(T start = default(T), bool startAtBeginning = true, Action<T> preVisit = null)
    {
        var visited = new HashSet<T>();

        GraphNode<T> startNode = null;
        if (!startAtBeginning)
        {
            if ((startNode = nodes.FindByValue(start)) == null)
                return visited;
        }
        else
        {
            startNode = nodes.FirstOrDefault();

            if (startNode == null) { return visited; }
        }

        var queue = new Queue<GraphNode<T>>();
        queue.Enqueue(startNode);

        while (queue.Count > 0)
        {
            var vertex = queue.Dequeue();

            if (visited.Contains(vertex.Value))
                continue;

            preVisit?.Invoke(vertex.Value);

            visited.Add(vertex.Value);

            foreach (var neighbor in vertex.Neighbors)
                if (!visited.Contains(neighbor.Value))
                    queue.Enqueue(neighbor);
        }

        return visited;
    }

    public HashSet<T> FindShortestPath(T node1, T node2)
    {
        var visited = new HashSet<T>();
        var path = new HashSet<T>();
        var previousPointer = new Dictionary<GraphNode<T>, GraphNode<T>>();

        GraphNode<T> startNode = null;
        GraphNode<T> endNode = null;

        if ((startNode = nodes.FindByValue(node1)) == null)
            return null;

        if ((endNode = nodes.FindByValue(node2)) == null)
            return null;

        var queue = new Queue<GraphNode<T>>();

        queue.Enqueue(startNode);

        while (queue.Count > 0)
        {
            var vertex = queue.Dequeue();

            if (previousPointer.ContainsKey(vertex))
                continue;

            if (visited.Contains(vertex.Value))
                continue;

            visited.Add(vertex.Value);

            if (vertex.Value.CompareTo(endNode.Value) == 0)
            {
                break; 
            }

            foreach (var neighbor in vertex.Neighbors)
            {
                if (previousPointer.ContainsKey(neighbor))
                    continue;

                previousPointer.Add(neighbor, vertex);
                queue.Enqueue(neighbor);
            }
        }

        var current = endNode;
        while (!current.Equals(startNode))
        {
            path.Add(current.Value);
            current = previousPointer[current];
        };

        path.Add(startNode.Value);
        path.Reverse();

        return path;
    }

    public void PrintConnectedComponents()
    {
        bool[] visited = new bool[nodes.Count];
        int[] componentIds = new int[nodes.Count];
        int count = 0;

        for (int i = 0; i < nodes.Count; i++)
        {
            DFS(nodes.FirstOrDefault() , i, visited, count, componentIds);
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

    private void DFS(GraphNode<T> node, int index, bool[] visited, int count, int[] componentIds)
    {
        if (!visited[index])
        {
            visited[index] = true;
            componentIds[index] = count;
            foreach (var child in node.Neighbors)
            {
                DFS(child, index, visited, count, componentIds);
            }
        }
    }

    public ICollection<T> TopSort()
    {
        //preprocess -> predecessors by vertex
        var predecessorsCount = new Dictionary<GraphNode<T>, int>();

        foreach (var node in nodes)
        {
                if (predecessorsCount.ContainsKey(node))
                {
                    predecessorsCount[node]++;
                }
                else
                {
                    predecessorsCount.Add(node, 1);
                }
        }
        //find V with no parents
        var sortedGraph = new List<T>();

        while (true)
        {
            var nodeWithoutSource = predecessorsCount.Keys
                .Where(x => predecessorsCount[x] == 0).FirstOrDefault();

            if (nodeWithoutSource != null)
            {
                //adjust predecessors count on children
                foreach (var orphan in nodeWithoutSource.Neighbors) 
                {
                    predecessorsCount[orphan]--;
                }

                //remove it
                this.Remove(nodeWithoutSource.Value);
                predecessorsCount.Remove(nodeWithoutSource);

                //add removed node to sort order
                sortedGraph.Add(nodeWithoutSource.Value);
            }
            else
            {
                break;
            }
        }

        //if in the end stil exists V's in graph - > exception for cycle
        if (nodes.Any())
        {
            throw new InvalidOperationException("Graph has cycle.");
        }

        return sortedGraph;
    }
}