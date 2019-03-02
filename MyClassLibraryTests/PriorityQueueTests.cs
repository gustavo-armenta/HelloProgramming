using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibraryTests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void Unbound()
        {
            var p = new PriorityQueue<int>();
            p.Enqueue(100);
            p.Enqueue(50);
            p.Enqueue(75);
            p.Enqueue(65);
            p.Enqueue(85);
            p.Enqueue(25);
            p.Enqueue(40);
            p.Enqueue(10);
            p.Enqueue(1);
            var list = new List<int>();
            while (p.Count > 0)
            {
                list.Add(p.Dequeue());
            }
            Assert.AreEqual("1,10,25,40,50,65,75,85,100", list.ToCsv());
        }
    }
}
