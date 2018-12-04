using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibraryTests
{
    [TestClass]
    public class DynamicProgrammingTests
    {
        [TestMethod]
        public void Fibonacci()
        {
            DynamicProgramming p = new DynamicProgramming();
            Assert.AreEqual(-1, p.Fibonacci(-1));
            Assert.AreEqual(0, p.Fibonacci(0));
            Assert.AreEqual(1, p.Fibonacci(1));
            Assert.AreEqual(1, p.Fibonacci(2));
            Assert.AreEqual(2, p.Fibonacci(3));
            Assert.AreEqual(3, p.Fibonacci(4));
            Assert.AreEqual(5, p.Fibonacci(5));
            Assert.AreEqual(8, p.Fibonacci(6));
            Assert.AreEqual(13, p.Fibonacci(7));
        }

        [TestMethod]
        public void LongestIncreasingSubsequence()
        {
            DynamicProgramming p = new DynamicProgramming();
            Assert.AreEqual("1,2,1,3,2,4,4,5,6", p.LongestIncreasingSubsequence(new List<int> { 10, 22, 9, 33, 21, 50, 41, 60, 80 }).ToCsv());
            Assert.AreEqual("1,1,2,2,3,4", p.LongestIncreasingSubsequence(new List<int> { 50, 3, 10, 7, 8, 9 }).ToCsv());
        }

        [TestMethod]
        public void LongestCommonSubsequence()
        {
            DynamicProgramming p = new DynamicProgramming();
            Assert.AreEqual("", p.LongestCommonSubsequence("ABCDEF", "GHIJKLM", 6, 7));
            Assert.AreEqual("GTAB", p.LongestCommonSubsequence("AGGTAB", "GXTXAYB", 6, 7));
        }

        [TestMethod]
        public void MinCoinChange()
        {
            DynamicProgramming p = new DynamicProgramming();
            string expected = "0,1,1,2,2,1,2,2,3,3,1,2,2,3,3,2,3,3,4,4,2,3,3,4,4,1,2,2,3,3,2,3,3,4,4,2,3,3,4,4,3,4,4,5,5,3,4,4,5,5,2,3,3,4,4,3,4,4,5,5,3,4,4,5,5,4,5,5,6,6,4,5,5,6,6,3,4,4,5,5,4,5,5,6,6,4,5,5,6,6,5,6,6,7,7,5,6,6,7,7,4";
            int[] coins = new int[] { 1, 2, 5, 10, 25 };
            Assert.AreEqual(expected, p.MinCoinChange(coins, 100).ToCsv());
        }
    }
}
