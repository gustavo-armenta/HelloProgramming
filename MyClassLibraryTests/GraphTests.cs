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
        public void TopologicalSort()
        {
            var g = new Dictionary<char, List<Edge<char>>>();
            g.Add('A', new List<Edge<char>> { new Edge<char>('B'), new Edge<char>('C') });
            g.Add('B', new List<Edge<char>> { new Edge<char>('D'), new Edge<char>('E') });
            g.Add('C', new List<Edge<char>> { new Edge<char>('F'), new Edge<char>('G') });
            g.Add('D', new List<Edge<char>>());
            g.Add('E', new List<Edge<char>>());
            g.Add('F', new List<Edge<char>>());
            g.Add('G', new List<Edge<char>>());
            var p = new Graph<char>(g);
            Assert.AreEqual("D,E,B,F,G,C,A", p.TopologicalSort().ToCsv());
        }

        [TestMethod]
        public void Dijkstra()
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
            var r = p.Dijkstra('A');
            Assert.AreEqual("A,B,C,D,E,F,G", r.Keys.ToCsv());
            Assert.AreEqual("0,1,2,4,5,7,8", r.Values.ToCsv());
        }
    }
}
