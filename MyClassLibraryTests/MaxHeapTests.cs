using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;

namespace MyClassLibraryTests
{
    [TestClass]
    public class MaxHeapTests
    {
        [TestMethod]
        public void Unbound()
        {
            var p = new MaxHeap<int, int>();
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
            Assert.AreEqual("100,85,75,65,50,40,25,10,1", list.ToCsv());
        }

        [TestMethod]
        public void Bound()
        {
            var p = new MinHeap<int, int>(4);
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
            int count = 0;
            while (p.Count > 0)
            {
                list.Add(p.Dequeue().value);
                count++;
            }
            list.Reverse();
            Assert.AreEqual("100,85,75,65", list.ToCsv());
        }
    }
}
