using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibraryTests
{
    [TestClass]
    public class BacktrackingTests
    {
        [TestMethod]
        public void Permute()
        {
            Backtracking p = new Backtracking();
            Assert.AreEqual("ABC,ACB,BAC,BCA,CBA,CAB", p.Permute("ABC").ToCsv());
        }

        [TestMethod]
        public void FindPathInMaze()
        {
            Backtracking p = new Backtracking();
            int w = 10;
            int h = 10;
            var m = new int[w, h];
            Assert.AreEqual(true, p.FindPathInMaze(m, 0, 0, w - 1, h - 1));
        }

        [TestMethod]
        public void FindWordBoggle()
        {
            Backtracking p = new Backtracking();
            var a = new char[,]
            {
                { '*','*','*','*','*','*' },
                { '*','*','L','*','*','*' },
                { '*','C','D','O','*','*' },
                { '*','*','U','*','*','*' },
                { '*','*','*','*','*','*' },
                { '*','*','*','*','*','*' },
            };
            Assert.AreEqual(true, p.FindWordBoggle(a,"CLOUD"));
            Assert.AreEqual(false, p.FindWordBoggle(a, "CLOUDO"));
        }
    }
}
