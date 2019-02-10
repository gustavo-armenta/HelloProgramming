using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyClassLibrary
{
    public class Edge<T>
    {
        public T To { get; set; }
        public int Cost { get; set; }
        public Edge(T to)
        {
            To = to;
        }
        public Edge(T to, int cost)
        {
            To = to;
            Cost = cost;
        }
    }

    public class Graph<T>
    {
        private Dictionary<T, List<Edge<T>>> _graph;

        public Graph(Dictionary<T, List<Edge<T>>> graph)
        {
            _graph = graph;
        }

        public List<T> TopologicalSort()
        {
            var result = new List<T>();
            var visited = new SortedDictionary<T, bool>();
            foreach (var key in _graph.Keys)
            {
                visited.Add(key, false);
            }
            foreach (var node in visited.Keys.ToArray())
            {
                if (!IsChild(node))
                {
                    dfs(node, visited, result);
                }
            }
            return result;
        }

        // Find shortest path in graph without negative edges and cycles
        public SortedDictionary<T, int> Dijkstra(T sourceNode)
        {
            var minQueue = new SortedDictionary<int, HashSet<T>>();
            var distances = new SortedDictionary<T, int>();
            minQueue.Add(0, new HashSet<T>());
            minQueue[0].Add(sourceNode);
            while (minQueue.Count > 0)
            {
                int distance = minQueue.Keys.First();
                T node = minQueue[distance].First();
                minQueue[distance].Remove(node);
                if (minQueue[distance].Count == 0)
                {
                    minQueue.Remove(distance);
                }
                if (!distances.ContainsKey(node))
                {
                    distances.Add(node, distance);
                }
                else if (distances[node] > distance)
                {
                    distances[node] = distance;
                }
                foreach (var edge in _graph[node])
                {
                    int nextDistance = distances[node] + edge.Cost;
                    if (!minQueue.ContainsKey(nextDistance))
                    {
                        minQueue.Add(nextDistance, new HashSet<T>());
                    }
                    if (!minQueue[nextDistance].Contains(edge.To))
                    {
                        minQueue[nextDistance].Add(edge.To);
                    }
                }
            }

            return distances;
        }

        // Find shortest path without the restrictions of Dijkstra of only positive costs and no graph cycles
        public void BellmanFord() { }

        // Find shortest path for all node pairs using dynamic programming
        public void FloydWarshall()
        {
        }
        

        private bool IsChild(T node)
        {
            foreach (var (k, v) in _graph)
            {
                foreach (var item in v)
                {
                    if (item.To.Equals(node))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void dfs(T node, SortedDictionary<T, bool> visited, List<T> result)
        {
            if (visited[node]) return;
            visited[node] = true;
            foreach (var child in _graph[node])
            {
                dfs(child.To, visited, result);
            }
            result.Add(node);
        }
    }
}
