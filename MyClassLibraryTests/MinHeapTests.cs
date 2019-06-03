using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;

namespace MyClassLibraryTests
{
    [TestClass]
    public class MinHeapTests
    {
        [TestMethod]
        public void Unbound()
        {
            var p = new MinHeap<int, int>();
            p.Enqueue(100, 100);
            p.Enqueue(50, 50);
            p.Enqueue(75, 75);
            p.Enqueue(65, 65);
            p.Enqueue(85, 85);
            p.Enqueue(25, 25);
            p.Enqueue(40, 40);
            p.Enqueue(10, 10);
            p.Enqueue(1, 1);
            var list = new List<int>();
            while (p.Count > 0)
            {
                list.Add(p.Dequeue().value);
            }
            Assert.AreEqual("1,10,25,40,50,65,75,85,100", list.ToCsv());
        }

        [TestMethod]
        public void Bound()
        {
            var p = new MaxHeap<int, int>(4);
            p.Enqueue(100, 100);
            p.Enqueue(50, 50);
            p.Enqueue(75, 75);
            p.Enqueue(65, 65);
            p.Enqueue(85, 85);
            p.Enqueue(25, 25);
            p.Enqueue(40, 40);
            p.Enqueue(10, 10);
            p.Enqueue(1, 1);
            p.Enqueue(41, 41);
            p.Enqueue(42, 42);
            p.Enqueue(43, 43);
            var list = new List<int>();
            while (p.Count > 0)
            {
                list.Add(p.Dequeue().value);
            }
            list.Reverse();
            Assert.AreEqual("1,10,25,40", list.ToCsv());
        }
    }
}
