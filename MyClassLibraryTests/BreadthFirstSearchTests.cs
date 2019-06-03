using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibraryTests
{
    [TestClass]
    public class BreadthFirstSearchTests
    {
        [TestMethod]
        public void FindPathInMaze()
        {
            var p = new BreadthFirstSearch();
            int w = 10;
            int h = 10;
            var m = new int[w, h];
            Assert.AreEqual(true, p.FindPathInMaze(m, 0, 0, w - 1, h - 1));
        }
    }
}
