using System.Collections.Generic;

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

        public List<T> TopologicalSort_Kahn()
        {
            var list = new List<T>();
            var refs = new Dictionary<T, int>();
            var q = new Queue<T>();
            foreach (var node in _graph.Keys)
            {
                refs.Add(node, 0);
            }
            foreach (var node in _graph.Keys)
            {
                foreach (var edge in _graph[node])
                {
                    refs[edge.To]++;
                }
            }
            foreach (var (node, v) in refs)
            {
                if (v > 0) continue;
                q.Enqueue(node);

            }
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                list.Add(node);
                foreach (var edge in _graph[node])
                {
                    if (--refs[edge.To] == 0)
                    {
                        q.Enqueue(edge.To);
                    }
                }
            }
            return list;
        }

        // Find shortest path in graph without negative edges and without cycles
        public IDictionary<T, (int distance, T parent)> ShortestDistance_Dijkstra(T sourceNode)
        {
            var map = new Dictionary<T, (int distance, T parent)>();
            foreach (var node in _graph.Keys)
            {
                map.Add(node, (int.MaxValue, default));
            }

            var minq = new MinHeap<int, (T node, T parent)>();
            minq.Enqueue(0, (sourceNode, default));
            while (minq.Count > 0)
            {
                var item = minq.Dequeue();
                if (item.key < map[item.value.node].distance)
                {
                    map[item.value.node] = (item.key, item.value.parent);
                    foreach (var edge in _graph[item.value.node])
                    {
                        minq.Enqueue(map[item.value.node].distance + edge.Cost, (edge.To, item.value.node));
                    }
                }
            }

            return map;
        }

        // Find shortest path without the restrictions of Dijkstra of only positive costs and no graph cycles
        public void BellmanFord() { }

        // Find shortest path for all node pairs using dynamic programming
        public void FloydWarshall()
        {
        }

        public IDictionary<T, (int distance, T parent)> MinimumSpanningTree_Prim()
        {
            T sourceNode = default(T);
            var map = new Dictionary<T, (int distance, T parent)>();
            foreach (var node in _graph.Keys)
            {
                map.Add(node, (int.MaxValue, default));
                if (default(T).Equals(sourceNode) || _graph[node].Count > _graph[sourceNode].Count)
                    sourceNode = node;
            }

            var minq = new MinHeap<int, (T node, T parent)>();
            minq.Enqueue(0, (sourceNode, default));
            while (minq.Count > 0)
            {
                var item = minq.Dequeue();
                if (item.key < map[item.value.node].distance)
                {
                    map[item.value.node] = (item.key, item.value.parent);
                    foreach (var edge in _graph[item.value.node])
                    {
                        minq.Enqueue(edge.Cost, (edge.To, item.value.node));
                    }
                }
            }

            return map;
        }
    }
}
