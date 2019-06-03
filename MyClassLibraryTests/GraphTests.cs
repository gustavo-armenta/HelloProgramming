using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibraryTests
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void TopologicalSort_Kahn()
        {
            var g = new Dictionary<char, List<Edge<char>>>();
            g.Add('A', new List<Edge<char>> { new Edge<char>('B'), new Edge<char>('C') });
            g.Add('B', new List<Edge<char>> { new Edge<char>('D'), new Edge<char>('E') });
            g.Add('C', new List<Edge<char>> { new Edge<char>('F'), new Edge<char>('G') });
            g.Add('D', new List<Edge<char>>());
            g.Add('E', new List<Edge<char>>());
            g.Add('F', new List<Edge<char>>());
            g.Add('G', new List<Edge<char>>());
            g.Add('M', new List<Edge<char>> { new Edge<char>('N'), new Edge<char>('O') });
            g.Add('N', new List<Edge<char>> { new Edge<char>('P'), new Edge<char>('Q') });
            g.Add('O', new List<Edge<char>> { new Edge<char>('R'), new Edge<char>('S') });
            g.Add('P', new List<Edge<char>>());
            g.Add('Q', new List<Edge<char>>());
            g.Add('R', new List<Edge<char>>());
            g.Add('S', new List<Edge<char>>());
            var p = new Graph<char>(g);
            Assert.AreEqual("A,M,B,C,N,O,D,E,F,G,P,Q,R,S", p.TopologicalSort_Kahn().ToCsv());
        }

        [TestMethod]
        public void ShortestDistance_Dijkstra()
        {
            var g = new Dictionary<char, List<Edge<char>>>();
            g.Add('A', new List<Edge<char>> { new Edge<char>('B', 1), new Edge<char>('C', 2) });
            g.Add('B', new List<Edge<char>> { new Edge<char>('D', 3), new Edge<char>('E', 4) });
            g.Add('C', new List<Edge<char>> { new Edge<char>('F', 5), new Edge<char>('G', 6) });
            g.Add('D', new List<Edge<char>>());
            g.Add('E', new List<Edge<char>>());
            g.Add('F', new List<Edge<char>>());
            g.Add('G', new List<Edge<char>>());
            var p = new Graph<char>(g);
            var r = p.ShortestDistance_Dijkstra('A');
            Assert.AreEqual("A,B,C,D,E,F,G", r.Keys.ToCsv());
            Assert.AreEqual("(0, \0),(1, A),(2, A),(4, B),(5, B),(7, C),(8, C)", r.Values.ToCsv());
        }

        [TestMethod]
        public void MinimumSpanningTree_Prim()
        {
            var g = new Dictionary<char, List<Edge<char>>>();
            g.Add('A', new List<Edge<char>> { new Edge<char>('B', 1), new Edge<char>('C', 2) });
            g.Add('B', new List<Edge<char>> { new Edge<char>('D', 3), new Edge<char>('E', 4) });
            g.Add('C', new List<Edge<char>> { new Edge<char>('F', 5), new Edge<char>('G', 6) });
            g.Add('D', new List<Edge<char>>());
            g.Add('E', new List<Edge<char>>());
            g.Add('F', new List<Edge<char>>());
            g.Add('G', new List<Edge<char>>());
            var p = new Graph<char>(g);
            var r = p.MinimumSpanningTree_Prim();
            Assert.AreEqual("A,B,C,D,E,F,G", r.Keys.ToCsv());
            Assert.AreEqual("(0, \0),(1, A),(2, A),(3, B),(4, B),(5, C),(6, C)", r.Values.ToCsv());
        }
    }
}
