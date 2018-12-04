﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.AreEqual(true, p.FindPathInMaze(m, w, h));
        }
    }
}
